using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトを破壊するまでの時間(最低値)")] float _minTime;
    [SerializeField, Tooltip("オブジェクトを破壊するまでの時間(最高値)")] float _maxTime;
    void Start()
    {
        float destroyTime = Random.Range(_minTime, _maxTime + 1);
        Destroy(gameObject, destroyTime);
    }
}
