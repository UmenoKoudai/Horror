using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class Zombi : EnemyBase
{
    [SerializeField, Tooltip("�v���C���[�������Ă��Ȃ��Ƃ��ɏ��񂷂�ꏊ")] Transform[] _movePoint;
    [SerializeField, Tooltip("�ړI�n�ɂǂꂾ���߂Â���")] float _stopingDistance;
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")] int _moveSpeed;
    [SerializeField, Tooltip("�]���r�����ɋC�t������")] float _discoverArea;
    PlayerController _player;
    GameManager _gameManager;
    Animator _anim;
    Rigidbody _rb;
    int _movePointCount;
    int _power;
    public int Power { get => _power; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _player = GameObject.FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        if(base.HP < 0)
        {
            GameObject ragDoll = (GameObject)Resources.Load("RagDollZombi");
            Instantiate(ragDoll, transform.position, transform.rotation);
            GameManager.Instance.AddScore(base.Score);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if (playerDistance < _discoverArea)
        {
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
                float distance = Vector3.Distance(transform.position, footSountPoint[0].transform.position);
                if (distance > _stopingDistance)
                {
                    transform.LookAt(footSountPoint[footSountPoint.Length - 1].transform.position);
                    Vector3 dir = (footSountPoint[footSountPoint.Length - 1].transform.position - transform.position).normalized;
                    _rb.velocity = dir * _moveSpeed;
                }
            }
        }
    }
}
