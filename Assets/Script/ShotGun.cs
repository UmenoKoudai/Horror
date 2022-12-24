using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : WeaponBase
{
    [SerializeField, Tooltip("�Ə��̃C���X�g")] Image _crosshair;
    [SerializeField, Tooltip("�e�����˂���ꏊ")] Transform _muzzle;
    [SerializeField, Tooltip("�ʏ�̏Ə��̐F")] Color _defaultCrosshairColor;
    [SerializeField, Tooltip("�G�ɓ����������̏Ə��̐F")] Color _tagetLockCrosshairColor;
    [SerializeField, Tooltip("�˒�����")] float _shotRange;
    [SerializeField, Tooltip("�G�̃��C���[")] LayerMask _enemyLayer;
    [SerializeField, Tooltip("�e�̈З�")] int _gunPower;
    [SerializeField, Tooltip("�}�Y���t���b�V��")] GameObject _effect;
    [SerializeField, Tooltip("�V���b�g�K���͈̔�")] int _randomRange;
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
