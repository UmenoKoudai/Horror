using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : SingletonMonoBehaviour<HandIK>
{
    [SerializeField] GameObject _player;
    [SerializeField] Transform _leftTarget;
    [SerializeField] Transform _rightTarget;
    [SerializeField, Range(0f, 1f)] float _rightPositionWeight;
    [SerializeField, Range(0f, 1f)] float _rightRotationWeight;
    [SerializeField, Range(0f, 1f)] float _leftPositionWeight;
    [SerializeField, Range(0f, 1f)] float _leftRotationWeight;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        //_anim = GetComponentInParent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _anim.SetIKPosition(AvatarIKGoal.RightHand, _rightTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, _rightTarget.rotation);
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightPositionWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightRotationWeight);

        _anim.SetIKPosition(AvatarIKGoal.LeftHand, _leftTarget.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, _leftTarget.rotation);
        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, _leftPositionWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, _leftRotationWeight);
    }

    public void PositionChange(string name)
    {
        _rightTarget = GameObject.Find($"{name}(P)").transform.GetChild(0);
        _leftTarget = GameObject.Find($"{name}(P)").transform.GetChild(1);
        Debug.Log($"{_rightTarget.gameObject.name} {_leftTarget.gameObject.name}");
        GameObject obj = GameObject.Find($"{name}(P)");
        for(int i = 0; i < obj.transform.childCount; i++)
        {
            Debug.Log(obj.transform.GetChild(i).gameObject.name);
        }
    }
}
