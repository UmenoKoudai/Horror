using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] GameObject[] _moves;
    [SerializeField] Text _scoreText;
    [SerializeField]float _time;
    int _score;
    int _keyItemCount;
    event Action _enemyDestroy;

    public  Action EnemyDestroy { get => _enemyDestroy; set => _enemyDestroy = value; }
    public int KeyItemCount { get => _keyItemCount; set => _keyItemCount = value; }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        _scoreText.text = $"{_score}";
        if(FindObjectsOfType<ItemAction>().Length == 0)
        {
            Debug.Log("GameClea");
        }
        //プレイヤーが0になったらゲームオーバー
        if (FindObjectsOfType<PlayerController>().Length == 0)
        {
            Debug.Log("GameOver");
        }
    }   
    public void AddScore(int score)
    {
        _score += score;
    }
}
