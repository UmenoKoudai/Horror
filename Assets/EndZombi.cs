using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EndZombi : MonoBehaviour
{
    [SerializeField] GameObject _car;
    [SerializeField] int _moveSpeed;
    [SerializeField] int _addPower;
    [SerializeField] GameObject _ragDoll;
    Rigidbody _rb;
    Animator _anim;
    bool _isMove = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent <Animator>();
    }

    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        //int randomVoice = Random.Range(0, 4);
        //switch (randomVoice)
        //{
        //    case 0:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice1, 10f);
        //        break;
        //    case 1:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice2, 10f);
        //        break;
        //    case 2:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice3, 10f);
        //        break;
        //    case 3:
        //        AudioController.Instance.SePlay(SelectClip.EnemyVoice4, 10f);
        //        break;

        //}
        if (_isMove)
        {
            transform.LookAt(_car.transform.position);
            Vector3 dir = (new Vector3(_car.transform.position.x, 0, _car.transform.position.z) - transform.position).normalized;
            _rb.velocity = dir * _moveSpeed;
        }
        else
        {
            _rb.AddForce(new Vector3(1, 1, transform.forward.z).normalized * _addPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("a");
            _isMove = false;
            Destroy(gameObject, 3f);
        }
    }
}
