using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : WeaponBase
{
    [SerializeField, Tooltip("照準のイラスト")] Image _crosshair;
    [SerializeField, Tooltip("弾が発射する場所")] Transform _muzzle;
    [SerializeField, Tooltip("通常の照準の色")] Color _defaultCrosshairColor;
    [SerializeField, Tooltip("敵に当たった時の照準の色")] Color _tagetLockCrosshairColor;
    [SerializeField, Tooltip("射程距離")] float _shotRange;
    [SerializeField, Tooltip("敵のレイヤー")] LayerMask _enemyLayer;
    [SerializeField, Tooltip("弾の威力")] int _gunPower;
    [SerializeField, Tooltip("マズルフラッシュ")] GameObject _effect;
    [SerializeField, Tooltip("ショットガンの範囲")] int _randomRange;
    Vector3 _hitPosition;
    Collider _hitCollider = default;
    Vector3 _hitAngle = default;

    public override void Action()
    {
        _hitPosition = _muzzle.transform.position + _muzzle.transform.forward * _shotRange;
        for (int i = 0; i < 9; i++)
        {
            float x = Random.Range(-_randomRange, _randomRange);
            float y = Random.Range(-_randomRange, _randomRange);
            Vector3 shootRange = new Vector3(_crosshair.transform.position.x + x, _crosshair.transform.position.y + y, 0);
            Ray ray = Camera.main.ScreenPointToRay(shootRange);
            if (Physics.Raycast(ray, out RaycastHit hit, _shotRange, _enemyLayer))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red);
                _hitPosition = hit.point;
                _hitCollider = hit.collider;
                _hitAngle = hit.normal;
            }
            if (_hitCollider)
            {
                HitEffect(_hitPosition, _hitAngle, transform.forward, _effect);
                StartCoroutine(CrosshairColorChange(_crosshair, _defaultCrosshairColor, _tagetLockCrosshairColor));
                HitAction(_hitCollider, _gunPower);
            }
        }
    }
}
