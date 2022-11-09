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

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        Vector3 hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        Collider hitCollider = default;

        if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
        {
            Debug.Log("hit");
            hitPosition = hit.point;
            hitCollider = hit.collider;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            BulletLine(_muzzle.position);
            if(hitCollider)
            {
                BulletLine(hitPosition);
                StartCoroutine(CrosshairColorChange());
                Hit(hitCollider);
            }
        }
        //else
        //{
        //    BulletLine(_muzzlu.position);
        //}
    }

    void BulletLine(Vector3 endLine)
    {
        Instantiate(_muzzleEffect, endLine, transform.rotation);
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
