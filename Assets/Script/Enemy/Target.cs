using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : EnemyBase
{
    [SerializeField] GameObject _effect;

    void Update()
    {
        if (base.HP < 0)
        {
            GameManager.Instance.AddScore(base.Score);
            _effect.SetActive(true);
            Destroy(gameObject);
        }
    }
}
