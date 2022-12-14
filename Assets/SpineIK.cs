using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineIK : MonoBehaviour
{
    [SerializeField] Transform _target;
    [Tooltip("どれくらい見るか")]
    [SerializeField, Range(0f, 1f)] float _weight;
    [Tooltip("体をどれくらい向けるか")]
    [SerializeField, Range(0f, 1f)] float _bodyWeight;
    [Tooltip("頭をどれくらい向けるか")]
    [SerializeField, Range(0f, 1f)] float _headWeight;
    [Tooltip("目をどれくらい向けるか")]
    [SerializeField, Range(0f, 1f)] float _eyesWeight;
    [Tooltip("間接の動きをどれくらい制限するか")]
    [SerializeField, Range(0f, 1f)] float _clampWeight;
    Animator _anim;
    Vector3 cameraPosition;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cameraPosition = Camera.main.transform.position;
        //scameraPosition.z = transform.position.z + 10;
        cameraPosition = Camera.main.transform.TransformDirection(cameraPosition);
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _anim.SetLookAtWeight(_weight, _bodyWeight, _headWeight, _eyesWeight, _clampWeight);
        _anim.SetLookAtPosition(cameraPosition);
    }
}
