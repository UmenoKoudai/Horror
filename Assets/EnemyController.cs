using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int _hp;
    TargetController _target;
    NavMeshAgent _nav;
    int _power;
    public int Power { get => _power; }

    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _target = GameObject.FindObjectOfType<TargetController>();
        _nav.SetDestination(_target.transform.position);

    }
    void Update()
    {
        if(_hp < 0)
        {
            Debug.Log("�G�l�~�[��|����");
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        Debug.Log($"�G��{damage}�_���[�W�^����");
        _hp -= damage;
    }
}
