using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _moves;
    [SerializeField] Text _timerText;
    [SerializeField]float _time;
    float _startTime;
    event Action _enemyDestroy;
    int _nowMove;


    public  Action EnemyDestroy { get => _enemyDestroy; set => _enemyDestroy = value; }

    void Start()
    {
        Cursor.visible = false;
        _startTime = _time;
    }

    void Update()
    {
        _time -= Time.deltaTime;
        _timerText.text = $"{_time.ToString("f2")}";

        //制限時間を過ぎたらWaveを進める
        if (_time < 0 && _nowMove < _moves.Length)
        {
            _nowMove++;
            switch (_nowMove)
            {
                case 1:
                    _moves[_nowMove - 1].SetActive(false);
                    _enemyDestroy();
                    _moves[_nowMove].SetActive(true);
                    break;
                case 2:
                    _moves[_nowMove - 1].SetActive(false);
                    _enemyDestroy();
                    _moves[_nowMove].SetActive(true);
                    break;
                case 3:
                    _moves[_nowMove - 1].SetActive(false);
                    _enemyDestroy();
                    _moves[_nowMove].SetActive(true);
                    break;
            }
            _time = _startTime;
        }
        //最後のMaveまでクリアしたらステージクリア
        else
        {
            Debug.Log("GameClea");
        }
        //護衛対象が0になったらゲームオーバー
        if(FindObjectsOfType<TargetController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
        //プレイヤーが0になったらゲームオーバー
        if (FindObjectsOfType<PlayerController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
    }
}
