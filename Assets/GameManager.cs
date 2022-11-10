using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float _timer;

    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer < 0)
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
