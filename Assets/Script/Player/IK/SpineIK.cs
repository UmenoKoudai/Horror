using UnityEngine;
using UnityEngine.UI;

public class SpineIK : MonoBehaviour
{
    [SerializeField] Image _crosshair;
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
        cameraPosition = Camera.main.ScreenToWorldPoint(_crosshair.transform.position);
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _anim.SetLookAtWeight(_weight, _bodyWeight, _headWeight, _eyesWeight, _clampWeight);
        _anim.SetLookAtPosition(-cameraPosition);
    }
}
