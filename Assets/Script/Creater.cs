using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField,Header("敵を出現させる位置")] Transform[] _positions;
    [SerializeField,Header("出現させる敵のPrefab")] GameObject[] _enemys;
    [SerializeField,Header("敵を出現させる間隔")] int _intarval;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        //出現位置をランダムで取得
        var randomPosition = Random.Range(0, _positions.Length - 1);
        //出現する敵をランダムで取得
        var randomEnemy = Random.Range(0, _enemys.Length - 1);
        //一定の間隔でランダムに敵を出現
        if(_timer > _intarval)
        {
            Instantiate(_enemys[randomEnemy], _positions[randomPosition].position, transform.rotation);
            _timer = 0;
        }
    }
}
