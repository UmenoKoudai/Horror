using UnityEngine;
using UnityEngine.UI;

public class SpineIK : MonoBehaviour
{
    [SerializeField] Image _crosshair;
    [Tooltip("‚Ç‚ê‚­‚ç‚¢Œ©‚é‚©")]
    [SerializeField, Range(0f, 1f)] float _weight;
    [Tooltip("‘Ì‚ğ‚Ç‚ê‚­‚ç‚¢Œü‚¯‚é‚©")]
    [SerializeField, Range(0f, 1f)] float _bodyWeight;
    [Tooltip("“ª‚ğ‚Ç‚ê‚­‚ç‚¢Œü‚¯‚é‚©")]
    [SerializeField, Range(0f, 1f)] float _headWeight;
    [Tooltip("–Ú‚ğ‚Ç‚ê‚­‚ç‚¢Œü‚¯‚é‚©")]
    [SerializeField, Range(0f, 1f)] float _eyesWeight;
    [Tooltip("ŠÔÚ‚Ì“®‚«‚ğ‚Ç‚ê‚­‚ç‚¢§ŒÀ‚·‚é‚©")]
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
