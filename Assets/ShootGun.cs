using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    [SerializeField] Image _crosshair;
    [SerializeField] Transform _muzzle;
    [SerializeField] Color _defaultCrosshairColor;
    [SerializeField] Color _tagetLockCrosshairColor;
    [SerializeField] float _shotRange;
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] int _gunPower;
    [SerializeField] GameObject _muzzleEffect;
    [SerializeField] float _shootIntarval;
    [SerializeField] int _randomRange;
    float _timer;

    void Update()
    { 
        Vector3 hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        Collider hitCollider = default;
        Vector3 hitAngle = default;
        _timer += Time.deltaTime;

        if (_timer > _shootIntarval)
        {
            if (Input.GetButton("Fire1"))
            {
                for (int i = 0; i < 9; i++)
                {
                    float x = Random.Range(-_randomRange, _randomRange);
                    float y = Random.Range(-_randomRange, _randomRange);
                    Vector3 shootRange = new Vector3(_crosshair.transform.position.x + x, _crosshair.transform.position.y + y, 0);
                    Ray ray = Camera.main.ScreenPointToRay(shootRange);
                    if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
                    {
                        Debug.DrawRay(ray.origin, ray.direction,Color.red);
                        hitPosition = hit.point;
                        hitCollider = hit.collider;
                        hitAngle = hit.normal;
                    }
                    if (hitCollider)
                    {
                        HitEffect(hitPosition, hitAngle);
                        StartCoroutine(CrosshairColorChange());
                        HitAction(hitCollider);
                    }
                }
                _timer = 0;
            }
        }
    }

    void HitEffect(Vector3 endLine, Vector3 hitAngle)
    {
        Instantiate(_muzzleEffect, endLine, Quaternion.FromToRotation(transform.forward, hitAngle));
    }

    void HitAction(Collider enemyCollider)
    {
        var hitEnemy = enemyCollider.GetComponent<EnemyController>();
        hitEnemy.Damage(_gunPower);
    }

    IEnumerator CrosshairColorChange()
    {
        _crosshair.color = _tagetLockCrosshairColor;
        yield return new WaitForSeconds(0.3f);
        _crosshair.color = _defaultCrosshairColor;
    }
}
