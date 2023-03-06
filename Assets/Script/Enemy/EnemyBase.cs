using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] int _hp;
    [SerializeField, Tooltip("�G�l�~�[��|�����Ƃ��ɓ�����X�R�A")] int _score;

    public int HP { get => _hp; set => _hp = value; }
    public int Score { get => _score; }

    public void Damage(int damage)
    {
        _hp -= damage;
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }
}
