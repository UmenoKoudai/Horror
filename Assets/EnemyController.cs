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
            Debug.Log("エネミーを倒した");
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        Debug.Log($"敵に{damage}ダメージ与えた");
        _hp -= damage;
    }
}
