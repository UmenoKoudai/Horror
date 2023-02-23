using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトを破壊するまでの時間")] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
