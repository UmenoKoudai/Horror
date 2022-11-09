using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Weapon : MonoBehaviour
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
    float _timer;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        Vector3 hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        Collider hitCollider = default;
        Vector3 hitAngle = default;
        _timer += Time.deltaTime;

        if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
        {
            Debug.Log("hit");
            hitPosition = hit.point;
            hitCollider = hit.collider;
            hitAngle = hit.normal;
        }
        if (_timer > _shootIntarval)
        {
            if (Input.GetButton("Fire1"))
            {
                BulletLine(_muzzle.position);
                if (hitCollider)
                {
                    BulletLine(hitPosition, hitAngle);
                    StartCoroutine(CrosshairColorChange());
                    Hit(hitCollider);
                }
                _timer = 0;
            }
        }
    }

    void BulletLine(Vector3 endLine)
    {
        Instantiate(_muzzleEffect, endLine, transform.rotation);
        //Debug.Log("BulletLine");
        //Vector3[] points = { _muzzle.position, endLine };
        //_bulletLine.positionCount = points.Length;
        //_bulletLine.SetPositions(points);
    }

    void BulletLine(Vector3 endLine, Vector3 hitAngle)
    {
        Debug.Log(endLine);
        Debug.Log(Quaternion.FromToRotation(transform.forward, hitAngle));
        Instantiate(_muzzleEffect, endLine, Quaternion.FromToRotation(transform.forward, hitAngle));
        //Debug.Log("BulletLine");
        //Vector3[] points = { _muzzle.position, endLine };
        //_bulletLine.positionCount = points.Length;
        //_bulletLine.SetPositions(points);
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
