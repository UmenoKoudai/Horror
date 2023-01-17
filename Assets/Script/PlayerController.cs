using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("照準のイメージ")] Image _crosshair;
    [SerializeField, Tooltip("Rayの長さ")] int _rayCastRange;
    [SerializeField, Tooltip("取得するアイテムのレイヤー")] LayerMask _actionObjectLayer;
    [SerializeField, Tooltip("武器名のアイコンのイメージ")] Text _getIcon;
    [SerializeField, Tooltip("切り替えるための武器を格納")] GameObject[] _weapons;
    [SerializeField, Tooltip("ダッシュ時の移動速度")] int _dushSpeed;
    [SerializeField, Tooltip("プレイヤーの移動速度")] int _defaultSpeed;
    [SerializeField, Tooltip("足音のオブジェクト")] GameObject _footSoundObject;
    Rigidbody _rb;
    Animator _anim;
    string _weaponName;
    float _h;
    float _v;
    int _moveSpeed = 10;
    public GameObject[] Weapons { get => _weapons; set => _weapons = value; }
    public string WeaponName { get=> _weaponName; }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        Cursor.visible = false;   
    }

    void Update()
    {
        
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        

        //アイテムを取得するためのRayCast
        Ray ray = Camera.main.ScreenPointToRay(_crosshair.transform.position);
        Debug.DrawRay(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out RaycastHit hit, _rayCastRange, _actionObjectLayer))
        {
            //Rayが当たったら武器の名前を表示
            _getIcon.gameObject.SetActive(true);
            _getIcon.text = $"{hit.collider.gameObject.name} F";
            GameObject hitObject = hit.collider.gameObject;
            //Rayが当たった状態でFボタンを押すと武器を拾う
            if (Input.GetKeyDown(KeyCode.F))
            {
                IAction action = hitObject.GetComponent<IAction>();
                _weaponName = hitObject.name;
                action.Action();
                //_weapons.WeaponChange(Array.FindIndex(_weapons, i => i.name == hit.collider.gameObject.name));
            }
        }
        //当たってないときはアイコンを非表示
        else
        {
            _getIcon.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        //Test1
        //視点移動のスクリプトカメラ方向に視線を移動する
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;//ここかも
        //常にカメラ方向を向く
        transform.forward = cameraForward;
        //spinePosition.z = cameraForward.z;

        //Test2
        //視点移動のスクリプトカメラ方向に視線を移動する
        Vector3 dirForward = Vector3.forward * _v + Vector3.right * _h;
        dirForward = Camera.main.transform.TransformDirection(dirForward);
        dirForward.y = 0;
        //動いている時はカメラ方向に視線を向ける
        if (dirForward != Vector3.zero && _v > 0 && _h == 0)
        {
            transform.forward = dirForward;
        }
        if (Input.GetButton("Fire4"))
        {
            _moveSpeed = _dushSpeed;
            Instantiate(_footSoundObject, transform.position, transform.rotation);
        }
        else
        {
            _moveSpeed = _defaultSpeed;
        }
        _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
