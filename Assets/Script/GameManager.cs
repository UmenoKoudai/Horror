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
        //switch(_nowMove)
        //{
        //    case 0:
        //        _moves[_nowMove].SetActive(true);
        //        break;
        //    case 1:
        //        _moves[_nowMove - 1].SetActive(false);
        //        _moves[_nowMove].SetActive(true);
        //        break;
        //    case 2:
        //        _moves[_nowMove - 1].SetActive(false);
        //        _moves[_nowMove].SetActive(true);
        //        break;
        //    case 3:
        //        _moves[_nowMove - 1].SetActive(false);
        //        _moves[_nowMove].SetActive(true);
        //        break;
        //}
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
        else if(_time < 0)
        {
            Debug.Log("GameClea");
        }
        if(FindObjectsOfType<TargetController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
        if(FindObjectsOfType<PlayerController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
    }
}
