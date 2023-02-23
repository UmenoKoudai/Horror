using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSound : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトが消える時間")] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
