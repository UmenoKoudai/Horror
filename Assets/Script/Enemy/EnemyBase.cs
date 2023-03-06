using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField, Tooltip("エネミーの体力")] int _hp;
    [SerializeField, Tooltip("エネミーを倒したときに得られるスコア")] int _score;

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
