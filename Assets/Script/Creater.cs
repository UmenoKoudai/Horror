using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] Transform[] _positions;
    [SerializeField] GameObject[] _enemys;
    [SerializeField] int _intarval;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        var randomPosition = Random.Range(0, _positions.Length - 1);
        var randomEnemy = Random.Range(0, _enemys.Length - 1);
        if(_timer > _intarval)
        {
            Instantiate(_enemys[randomEnemy], _positions[randomPosition].position, transform.rotation);
            _timer = 0;
        }
    }
}
