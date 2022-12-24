using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] GameObject _effect;
    [SerializeField] int _score;
    TargetController _target;
    NavMeshAgent _nav;
    GameManager _gameManager;
    int _power;
    public int Power { get => _power; }

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        //_nav = GetComponent<NavMeshAgent>();
        //_target = GameObject.FindObjectOfType<TargetController>();
        //_nav.SetDestination(_target.transform.position);
        //_gameManager.EnemyDestroy += EnemyDestroy;

    }
    void Update()
    {
        if(_hp < 0)
        {
            _gameManager.AddScore(_score);
            _effect.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }
}
