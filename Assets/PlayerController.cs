using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] Image _crosshair;
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
        var mousePoint = Camera.main.ScreenToWorldPoint(_crosshair.transform.position);
        transform.forward = mousePoint;
        //if (dir != Vector3.zero)
        //{
        //    transform.forward = mousePoint;
        //}
        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
