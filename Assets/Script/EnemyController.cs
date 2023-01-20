using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("エネミーの体力")] int _hp;
    [SerializeField, Tooltip("体力が0になった時に出すオブジェクト")] GameObject _effect;
    [SerializeField, Tooltip("エネミーを倒したときに得られるスコア")] int _score;
    [SerializeField, Tooltip("プレイヤーが動いていないときに巡回する場所")] Transform[] _movePoint;
    [SerializeField, Tooltip("目的地にどれだけ近づくか")] float _stopingDistance;
    [SerializeField, Tooltip("エネミーの移動速度")] int _moveSpeed;
    PlayerController _player;
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
        _player = GameObject.FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        if(_hp < 0)
        {
            _gameManager.AddScore(_score);
            _effect.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float playerDisyance = Vector3.Distance(transform.position, _player.transform.position);
        if (FindObjectsOfType<FootSound>().Length <= 0)
        {
            int nowposition = _movePointCount % _movePoint.Length;
            float distance = Vector3.Distance(transform.position, _movePoint[nowposition].position);
            if (distance > _stopingDistance)
            {
                transform.LookAt(_movePoint[nowposition].position);
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
            var footSountPoint = GameObject.FindGameObjectsWithTag("FootSound");
            //var soundPoint = footSountPoint.OrderByDescending(i => i).ToArray(); //←ここが問題何をソートするかわからないって言ってる？
            float distance = Vector3.Distance(transform.position, footSountPoint[0].transform.position);
            if (distance > _stopingDistance)
            {
                transform.LookAt(footSountPoint[footSountPoint.Length - 1].transform.position);
                Vector3 dir = (footSountPoint[footSountPoint.Length - 1].transform.position - transform.position).normalized;
                _rb.velocity = dir * _moveSpeed;
            }
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
