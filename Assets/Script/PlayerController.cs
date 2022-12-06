using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField,Header("プレイヤーの移動速度")] int _moveSpeed;
    [SerializeField,Header("照準のイメージ")] Image _crosshair;
    [SerializeField,Header("Rayの長さ")] int _rayCastRange;
    [SerializeField,Header("取得するアイテムのレイヤー")] LayerMask _weaponLayer;
    [SerializeField,Header("武器名のアイコンのイメージ")] Text _getIcon;
    [SerializeField,Header("切り替えるための武器を格納")] GameObject[] _weapons;
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
        //視点移動のスクリプトカメラ方向に視線を移動する
        Vector3 dir = Vector3.forward * _v + Vector3.right * _h;
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;
        //動いている時はカメラ方向に視線を向ける
        if (dir != Vector3.zero)
        {
            transform.forward = dir;
        }
        _rb.velocity = dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;

        //アイテムを取得するためのRayCast
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayCastRange, _weaponLayer))
        {
            //Rayが当たったら武器の名前を表示
            _getIcon.gameObject.SetActive(true);
            _getIcon.text = $"{hit.collider.gameObject.name} F";
            //Rayが当たった状態でFボタンを押すと武器を拾う
            if (Input.GetKeyDown(KeyCode.F))
            {
                _weapons.WeaponChange(hit.collider.GetComponent<WeaponID>()._id);
            }
        }
        //当たってないときはアイコンを非表示
        else
        {
            _getIcon.gameObject.SetActive(false);
        }
    }
}
