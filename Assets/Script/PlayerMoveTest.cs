using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [SerializeField] int _moveSpeed;
    Rigidbody _rb;
    float _h;
    float _v;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        //Test1
        //���_�ړ��̃X�N���v�g�J���������Ɏ������ړ�����
        Vector3 cameraForward= Camera.main.transform.TransformDirection(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        cameraForward.y = 0;
        //��ɃJ��������������
        if(cameraForward.y > 0)
        transform.forward = cameraForward;

        //Test2
        //���_�ړ��̃X�N���v�g�J���������Ɏ������ړ�����
        Vector3 dirForward = Vector3.forward * _v + Vector3.right * _h;
        dirForward = Camera.main.transform.TransformDirection(dirForward);
        dirForward.y = 0;
        Debug.Log($"Vertical:{_v}, Horizontal:{_h}");
        //�����Ă��鎞�̓J���������Ɏ�����������
        if (dirForward != Vector3.zero && _v > 0 && _h == 0)
        {
            transform.forward = dirForward;
        }
        _rb.velocity = dirForward.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
