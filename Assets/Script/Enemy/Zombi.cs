using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class Zombi : EnemyBase
{
    //[SerializeField, Tooltip("�v���C���[�������Ă��Ȃ��Ƃ��ɏ��񂷂�ꏊ")] Transform[] _movePoint;
    [SerializeField, Tooltip("�ړI�n�ɂǂꂾ���߂Â���")] float _stopingDistance;
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")] int _moveSpeed;
    [SerializeField, Tooltip("�]���r�����ɋC�t������")] float _discoverArea;
    Animator _anim;
    Rigidbody _rb;
    List<Transform> _movePoint = new List<Transform>();
    int _movePointCount;
    int _power;
    public int Power { get => _power; }
    public List<Transform> MovePoint { get => _movePoint; set => _movePoint = value; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        //�]���r��voice�������_���ɍĐ�
        //int randomVoice = Random.Range(0, 4);
        //switch (randomVoice)
        //{
        //    case 0:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice1, 20f);
        //        break;
        //    case 1:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice2, 20f);
        //        break;
        //    case 2:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice3, 20f);
        //        break;
        //    case 3:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice4, 20f);
        //        break;

        //}
        //HP���[���ɂȂ����烉�O�h�[���𐶐����I�u�W�F�N�g���폜����
        if (base.HP < 0)
        {
            GameObject ragDoll = (GameObject)Resources.Load("RagDollZombi");
            Instantiate(ragDoll, transform.position, transform.rotation);
            GameManager.Instance.AddScore(base.Score);
            EnemyCreate.Instance.CreateEnemy();
            base.HP = 10;
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if (FindObjectsOfType<FootSound>().Length <= 0 || playerDistance > _discoverArea)
        {
            int nowposition = _movePointCount % _movePoint.Count;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneSystem.Instance.SceneChange("GameOver");
        }
    }
}
