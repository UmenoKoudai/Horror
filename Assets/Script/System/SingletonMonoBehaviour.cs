using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    var typeName = typeof(T);
                    Debug.LogError($"{typeName}���A�^�b�`����Ă���I�u�W�F�N�g������܂���");
                }
            }
            return _instance;
        }
    }
}
