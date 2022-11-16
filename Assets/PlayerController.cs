using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    [SerializeField] Image _crosshair;
    [SerializeField] int _rayCastRange;
    [SerializeField] LayerMask _weaponLayer;
    [SerializeField] Text _getIcon;
    [SerializeField] GameObject[] _weapons;
    Rigidbody _rb;
    int n;
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
        //var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (dir != Vector3.zero)
        {
            transform.forward = dir;
        }
        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;

        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayCastRange, _weaponLayer))
        {
            _getIcon.gameObject.SetActive(true);
            _getIcon.text = $"{hit.collider.gameObject.name} F";
            if (Input.GetKeyDown(KeyCode.F))
            {
                for (int i = 0; i < _weapons.Length; i++)
                {
                    _weapons[i].SetActive(false);
                }
                _weapons[hit.collider.GetComponent<WeaponID>()._id].SetActive(true);
                //_weapons[Array.FindIndex(_weapons,i => i.name == hit.collider.gameObject.name)].SetActive(true);
            }
        }
        else
        {
            _getIcon.gameObject.SetActive(false);
        }
    }
}
