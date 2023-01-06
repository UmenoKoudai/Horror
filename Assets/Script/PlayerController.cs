using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの移動速度")] int _moveSpeed;
    [SerializeField, Header("照準のイメージ")] Image _crosshair;
    [SerializeField, Header("Rayの長さ")] int _rayCastRange;
    [SerializeField, Header("取得するアイテムのレイヤー")] LayerMask _actionObjectLayer;
    [SerializeField, Header("武器名のアイコンのイメージ")] Text _getIcon;
    [SerializeField, Header("切り替えるための武器を格納")] GameObject[] _weapons;
    Vector3 _camera;
    [SerializeField] Transform _spine;
    //[SerializeField] Transform _myCamera;
    Rigidbody _rb;
    Animator _anim;
    string _weaponName;
    float _h;
    float _v;
    public GameObject[] Weapons { get => _weapons; set => _weapons = value; }
    public string WeaponName { get=> _weaponName; }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        Cursor.visible = false;
        _camera = Camera.main.transform.position;
        
    }

    void Update()
    {
        var spinePosition = _spine.transform.position;
        //_spine.rotation = Quaternion.Euler(_spine.localEulerAngles.x, _spine.localEulerAngles.y, _spine.localEulerAngles.z + _myCamera.localEulerAngles.x);
        _anim.SetFloat("MoveSpeed", _rb.velocity.z);
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
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
        _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;

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
}
