using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _moves;
    int _nowMove;
    float _timer;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        switch(_nowMove)
        {
            case 0:
                _moves[_nowMove].SetActive(true);
                break;
            case 1:
                _moves[_nowMove - 1].SetActive(false);
                _moves[_nowMove].SetActive(true);
                break;
            case 2:
                _moves[_nowMove - 1].SetActive(false);
                _moves[_nowMove].SetActive(true);
                break;
            case 3:
                _moves[_nowMove - 1].SetActive(false);
                _moves[_nowMove].SetActive(true);
                break;
        }
        if(_timer < 0 && _nowMove < _moves.Length)
        {
            _nowMove++;
            _timer = 0;
        }
        else
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
