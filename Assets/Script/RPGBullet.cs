using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RPGBullet : MonoBehaviour
{
    [SerializeField, Tooltip("’e‚ÌˆÚ“®‘¬“x")] int _moveSpeed;
    Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Shot");
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.forward * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameObject bullet = (GameObject)Resources.Load("GameObject");
            Instantiate(bullet, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
