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

        //�������Ԃ��߂�����Wave��i�߂�
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
        //�Ō��Mave�܂ŃN���A������X�e�[�W�N���A
        else
        {
            Debug.Log("GameClea");
        }
        //��q�Ώۂ�0�ɂȂ�����Q�[���I�[�o�[
        if(FindObjectsOfType<TargetController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
        //�v���C���[��0�ɂȂ�����Q�[���I�[�o�[
        if (FindObjectsOfType<PlayerController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
    }
}
