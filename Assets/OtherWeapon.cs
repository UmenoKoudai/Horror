using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherWeapon : WeaponBase
{
    [SerializeField] Image _crosshair;
    [SerializeField] Transform _muzzle;
    [SerializeField] Color _defaultCrosshairColor;
    [SerializeField] Color _tagetLockCrosshairColor;
    [SerializeField] float _shotRange;
    [SerializeField] LayerMask _enemyLayer;
    [SerializeField] int _gunPower;
    [SerializeField] GameObject _effect;
    Vector3 _hitPosition;
    Collider _hitCollider = default;
    Vector3 _hitAngle = default;
    //public Vector3 HitPosition { get => _hitPosition; }
    //public Vector3 HitAngle { get => _hitAngle; }
    //public Collider HitCollider { get => _hitCollider; }
    //public GameObject Effect { get => _effect; }

    public override void Action()
    {
        _hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
        {
            Debug.Log("hit");
            _hitPosition = hit.point;
            _hitCollider = hit.collider;
            _hitAngle = hit.normal;
        }

        if (_hitCollider)
        {
            HitEffect(_hitPosition, _hitAngle);
            StartCoroutine(CrosshairColorChange());
            HitAction(_hitCollider);
        }
    }
    //void Update()
    //{
    //    Vector3 hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
    //    Collider hitCollider = default;
    //    Vector3 hitAngle = default;
    //    _timer += Time.deltaTime;

    //    if (_timer > _shootIntarval)
    //    {
    //        if (Input.GetButton("Fire1"))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
    //            if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
    //            {
    //                Debug.Log("hit");
    //                hitPosition = hit.point;
    //                hitCollider = hit.collider;
    //                hitAngle = hit.normal;
    //            }

    //            if (hitCollider)
    //            {
    //                HitEffect(hitPosition, hitAngle);
    //                StartCoroutine(CrosshairColorChange());
    //                HitAction(hitCollider);
    //            }
    //            _timer = 0;
    //        }
    //    }
    //}

    void HitEffect(Vector3 endLine, Vector3 hitAngle)
    {
        //Debug.Log(Quaternion.FromToRotation(transform.forward, hitAngle));
        Instantiate(_effect, endLine, Quaternion.FromToRotation(transform.forward, hitAngle));
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