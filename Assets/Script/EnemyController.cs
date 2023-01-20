using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] int _hp;
    [SerializeField, Tooltip("�̗͂�0�ɂȂ������ɏo���I�u�W�F�N�g")] GameObject _effect;
    [SerializeField, Tooltip("�G�l�~�[��|�����Ƃ��ɓ�����X�R�A")] int _score;
    [SerializeField, Tooltip("�v���C���[�������Ă��Ȃ��Ƃ��ɏ��񂷂�ꏊ")] Transform[] _movePoint;
    [SerializeField, Tooltip("�ړI�n�ɂǂꂾ���߂Â���")] float _stopingDistance;
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")] int _moveSpeed;
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
            //var soundPoint = footSountPoint.OrderByDescending(i => i).ToArray(); //����������艽���\�[�g���邩�킩��Ȃ����Č����Ă�H
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
