using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherWeapon : WeaponBase
{
    [SerializeField, Tooltip("�Ə��̃C���X�g")] Image _crosshair;
    [SerializeField, Tooltip("�e�����˂���ꏊ")] Transform _muzzle;
    [SerializeField, Tooltip("�ʏ�̏Ə��̐F")] Color _defaultCrosshairColor;
    [SerializeField, Tooltip("�G�ɓ����������̏Ə��̐F")] Color _tagetLockCrosshairColor;
    [SerializeField, Tooltip("�˒�����")] float _shotRange;
    [SerializeField, Tooltip("�G�̃��C���[")] LayerMask _enemyLayer;
    [SerializeField, Tooltip("�e�̈З�")] int _gunPower;
    [SerializeField, Tooltip("�}�Y���t���b�V��")] GameObject _effect;
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
