using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Weapon1 : MonoBehaviour
{
    [SerializeField] Image _crosshair;
    [SerializeField] Transform _muzzle;
    [SerializeField] Color _defaultCrosshairColor;
    [SerializeField] Color _tagetLockCrosshairColor;
    [SerializeField] float _shotRange;
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] LineRenderer _bulletLine;
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

        //for(int i = 0; i < 10; i++)
        //{
        //    float x = Random.Range(-3, 3);
        //    float y = Random.Range(-3, 3);
        //    Vector3 shootRange = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        //    Ray ray = Camera.main.ScreenPointToRay(shootRange);
        //    if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
        //    {
        //        Debug.DrawRay(ray.origin,ray.direction);
        //        Debug.Log("hit");
        //        hitPosition = hit.point;
        //        hitCollider = hit.collider;
        //        hitAngle = hit.normal;
        //    }
        //}
        
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
                        BulletLine(hitPosition, hitAngle);
                        StartCoroutine(CrosshairColorChange());
                        Hit(hitCollider);
                    }
                    //Debug.Log($"{i}‰ñ–Ú‚Ì”ÍˆÍ‚ÍX:{x}Y:{y}‚Å‚·");
                }
                //BulletLine(_muzzle.position);
                //if (hitCollider)
                //{
                //    BulletLine(hitPosition, hitAngle);
                //    StartCoroutine(CrosshairColorChange());
                //    Hit(hitCollider);
                //}
                _timer = 0;
            }
        }
    }

    void BulletLine(Vector3 endLine)
    {
        Instantiate(_muzzleEffect, endLine, transform.rotation);
    }

    void BulletLine(Vector3 endLine, Vector3 hitAngle)
    {
        Debug.Log(Quaternion.FromToRotation(transform.forward, hitAngle));
        Instantiate(_muzzleEffect, endLine, Quaternion.FromToRotation(transform.forward, hitAngle));
    }

    void Hit(Collider enemyCollider)
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
