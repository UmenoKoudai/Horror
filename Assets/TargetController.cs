using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] int _hp;

    void Update()
    {
        if(_hp < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var damage = collision.gameObject.GetComponent<EnemyController>().Power;
            _hp -= damage;
        }
    }
}
