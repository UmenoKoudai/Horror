using UnityEngine;

public class FootSound : MonoBehaviour
{
    [SerializeField, Tooltip("�I�u�W�F�N�g�������鎞��")] float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
