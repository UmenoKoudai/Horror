using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField,Header("�G���o��������ʒu")] Transform[] _positions;
    [SerializeField,Header("�o��������G��Prefab")] GameObject[] _enemys;
    [SerializeField,Header("�G���o��������Ԋu")] int _intarval;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        //�o���ʒu�������_���Ŏ擾
        var randomPosition = Random.Range(0, _positions.Length - 1);
        //�o������G�������_���Ŏ擾
        var randomEnemy = Random.Range(0, _enemys.Length - 1);
        //���̊Ԋu�Ń����_���ɓG���o��
        if(_timer > _intarval)
        {
            Instantiate(_enemys[randomEnemy], _positions[randomPosition].position, transform.rotation);
            _timer = 0;
        }
    }
}
