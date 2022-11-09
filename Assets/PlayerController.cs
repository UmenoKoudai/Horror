using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    Rigidbody _rb;
    float _h;
    float _v;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        //Vector3 dir = new Vector3(_h, transform.position.y, _v);
        Vector3 dir = Vector3.forward * _v + Vector3.right * _h;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        if(dir != Vector3.zero)
        {
            transform.forward = dir;
        }
        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
