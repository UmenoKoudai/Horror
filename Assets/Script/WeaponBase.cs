using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponBase : MonoBehaviour
{
    public static float _intarval;
    float _timer;

    public abstract void Action();

    void Update()
    {
        _timer += Time.deltaTime;
        Debug.Log(_timer);
        if (_intarval < _timer)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("shoot");
                Action();
                _timer = 0;
            }
        }
    }

    public static void IntarvalUpdate(float interval)
    {
        _intarval = interval;
    }
    /// <summary>
    /// �e�����������ʒu�ɃG�t�F�N�g�������Ɍ����Ĕ���������
    /// </summary>
    /// �I�u�W�F�N�g���C���X�^���X����ʒu
    /// <param name="endLine"></param>
    /// ��]���������
    /// <param name="hitAngle"></param>
    /// �e���΂�������
    /// <param name="startAngle"></param>
    /// �������������G�t�F�N�g
    /// <param name="effect"></param>
    public static void HitEffect(Vector3 endLine, Vector3 hitAngle, Vector3 startAngle,GameObject effect)
    {
        Instantiate(effect, endLine, Quaternion.FromToRotation(startAngle, hitAngle));
    }

    /// <summary>
    /// Ray�����������G�l�~�[�̃X�N���v�g�ɂ���_���[�W�֐������s����
    /// </summary>
    /// �q�b�g�����G�l�~�[�̃R���C�_�[
    /// <param name="enemyCollider"></param>
    /// �G�l�~�[�ɗ^����_���[�W��
    /// <param name="gunPower"></param>
    /// 
    public static void HitAction(Collider enemyCollider, int gunPower)
    {
        var hitEnemy = enemyCollider.GetComponent<EnemyController>();
        hitEnemy.Damage(gunPower);
    }

    /// <summary>
    /// �G�l�~�[�ɒe���q�b�g�������N���X�w�A�̐F��ς���
    /// </summary>
    /// �F��ς������N���X�w�A�̉摜
    /// <param name="crosshair"></param>
    /// �����������̐F
    /// <param name="afterColor"></param>
    /// �ʏ�̐F
    /// <param name="beforeColor"></param>
    /// <returns></returns>
    public static IEnumerator CrosshairColorChange(Image crosshair, Color afterColor, Color beforeColor)
    {
        crosshair.color = beforeColor;
        yield return new WaitForSeconds(0.3f);
        crosshair.color = afterColor;
    }
}