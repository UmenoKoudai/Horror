using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField,Header("“G‚ðoŒ»‚³‚¹‚éˆÊ’u")] Transform[] _positions;
    [SerializeField,Header("oŒ»‚³‚¹‚é“G‚ÌPrefab")] GameObject[] _enemys;
    [SerializeField,Header("“G‚ðoŒ»‚³‚¹‚éŠÔŠu")] int _intarval;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        //oŒ»ˆÊ’u‚ðƒ‰ƒ“ƒ_ƒ€‚ÅŽæ“¾
        var randomPosition = Random.Range(0, _positions.Length - 1);
        //oŒ»‚·‚é“G‚ðƒ‰ƒ“ƒ_ƒ€‚ÅŽæ“¾
        var randomEnemy = Random.Range(0, _enemys.Length - 1);
        //ˆê’è‚ÌŠÔŠu‚Åƒ‰ƒ“ƒ_ƒ€‚É“G‚ðoŒ»
        if(_timer > _intarval)
        {
            Instantiate(_enemys[randomEnemy], _positions[randomPosition].position, transform.rotation);
            _timer = 0;
        }
    }
}
