using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] GameObject _effect;
    [SerializeField] int _score;
    [SerializeField] Transform[] _movePoint;
    [SerializeField] float _stopingDistance;
    [SerializeField] int _moveSpeed;
    int _movePointCount;
    GameManager _gameManager;
    int _power;
    Rigidbody _rb;
    public int Power { get => _power; }
    Animator _anim;

    private void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        if(FindObjectsOfType<FootSound>().Length <= 0)
        {
            int nowposition = _movePointCount % _movePoint.Length;
            float distance = Vector3.Distance(transform.position, _movePoint[nowposition].position);
            transform.LookAt(_movePoint[nowposition].position);
            if (distance > _stopingDistance)
            {
                Vector3 dir = (_movePoint[nowposition].position - transform.position).normalized;
                _rb.velocity = dir * _moveSpeed;
            }
            else
            {
                _movePointCount++;
            }
        }
        else
        {
            FootSound[] footSountPoint = GameObject.FindObjectsOfType<FootSound>();
            var soundPoint = footSountPoint.OrderByDescending(i => i).ToArray();
            float distance = Vector3.Distance(transform.position, soundPoint[0].transform.position);
            if(distance > _stopingDistance)
            {
                Vector3 dir = (soundPoint[0].transform.position - transform.position).normalized;
                _rb.velocity = dir * _moveSpeed;
            }
        }
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
