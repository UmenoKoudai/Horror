using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField, Tooltip("�I�u�W�F�N�g��j�󂷂�܂ł̎���")] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
