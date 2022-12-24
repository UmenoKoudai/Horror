using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherWeapon : WeaponBase
{
    [SerializeField, Tooltip("照準のイラスト")] Image _crosshair;
    [SerializeField, Tooltip("弾が発射する場所")] Transform _muzzle;
    [SerializeField, Tooltip("通常の照準の色")] Color _defaultCrosshairColor;
    [SerializeField, Tooltip("敵に当たった時の照準の色")] Color _tagetLockCrosshairColor;
    [SerializeField, Tooltip("射程距離")] float _shotRange;
    [SerializeField, Tooltip("敵のレイヤー")] LayerMask _enemyLayer;
    [SerializeField, Tooltip("弾の威力")] int _gunPower;
    [SerializeField, Tooltip("マズルフラッシュ")] GameObject _effect;
    Vector3 _hitPosition;
    Collider _hitCollider = default;
    Vector3 _hitAngle = default;

    public override void Action()
    {
        _hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
        {
            _hitPosition = hit.point;
            _hitCollider = hit.collider;
            _hitAngle = hit.normal;
        }

        if (_hitCollider)
        {
            HitEffect(_hitPosition, _hitAngle, transform.forward, _effect);
            StartCoroutine(CrosshairColorChange(_tagetLockCrosshairColor, _defaultCrosshairColor));
            HitAction(_hitCollider, _gunPower);
        }
        IEnumerator CrosshairColorChange(Color changeColor, Color defourtColor)
        {
            _crosshair.color = changeColor;
            yield return new WaitForSeconds(0.3f);
            _crosshair.color = defourtColor;
        }
    }
}
