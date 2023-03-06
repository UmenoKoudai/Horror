using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : SingletonMonoBehaviour<EnemyCreate>
{
    [SerializeField] float _interval;
    GameObject _zombiObject;
    Vector3 _basePosition;
    Zombi _zombiScript;
    bool _isCreate;
    float _timer;
    void Start()
    {
        _basePosition = transform.position;
        _zombiScript = _zombiObject.GetComponent<Zombi>();
        for(int i = 1; i < transform.childCount; i ++)
        {
            _zombiScript.MovePoint.Add(transform.GetChild(i));
        }
    }
    private void Update()
    {
        if(_isCreate)
        {
            Debug.Log("開始");
            _timer += Time.deltaTime;
            if(_timer > _interval)
            {
                Debug.Log("クリエイト");
                transform.GetChild(0).position = _basePosition;
                transform.GetChild(0).gameObject.SetActive(true);
                _timer = 0;
                _isCreate = false;
            }
        }
    }
    public void CreateEnemy()
    {
        _isCreate = true;
    }
}
