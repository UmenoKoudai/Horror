using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hp;

    void Update()
    {
        if(_hp < 0)
        {
            Debug.Log("�G�l�~�[��|����");
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        Debug.Log($"�G��{damage}�_���[�W�^����");
        _hp -= damage;
    }
}
