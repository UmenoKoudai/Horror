using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField, Tooltip("�I�u�W�F�N�g��j�󂷂�܂ł̎���(�Œ�l)")] float _minTime;
    [SerializeField, Tooltip("�I�u�W�F�N�g��j�󂷂�܂ł̎���(�ō��l)")] float _maxTime;
    void Start()
    {
        float destroyTime = Random.Range(_minTime, _maxTime + 1);
        Destroy(gameObject, destroyTime);
    }
}
