using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Zombi : EnemyBase
{
    [SerializeField, Tooltip("プレイヤーが動いていないときに巡回する場所")] Transform[] _movePoint;
    [SerializeField, Tooltip("目的地にどれだけ近づくか")] float _stopingDistance;
    [SerializeField, Tooltip("エネミーの移動速度")] int _moveSpeed;
    [SerializeField, Tooltip("ゾンビが音に気付く距離")] float _discoverArea;
    Animator _anim;
    Rigidbody _rb;
    int _movePointCount;
    int _power;
    public int Power { get => _power; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        _anim.SetFloat("MoveSpeed", _rb.velocity.magnitude);
        int randomVoice = Random.Range(0, 4);
        switch(randomVoice)
        {
            case 0:
                AudioController.Instance.SePlay(SelectClip.EnemyVoice1, 4f);
                break;
            case 1:
                AudioController.Instance.SePlay(SelectClip.EnemyVoice2, 4f);
                break;
            case 2:
                AudioController.Instance.SePlay(SelectClip.EnemyVoice3, 4f);
                break;
            case 3:
                AudioController.Instance.SePlay(SelectClip.EnemyVoice4, 4f);
                break;

        }
        if(base.HP < 0)
        {
            GameObject ragDoll = (GameObject)Resources.Load("RagDollZombi");
            Instantiate(ragDoll, transform.position, transform.rotation);
            GameManager.Instance.AddScore(base.Score);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float playerDistance = Vector3.Distance(transform.position, PlayerController.Instance.transform.position);
        if (playerDistance < _discoverArea)
        {
            if (FindObjectsOfType<FootSound>().Length <= 0)
            {
                int nowposition = _movePointCount % _movePoint.Length;
                float distance = Vector3.Distance(transform.position, _movePoint[nowposition].position);
                if (distance > _stopingDistance)
                {
                    transform.LookAt(_movePoint[nowposition].position);
                    Vector3 dir = (_movePoint[nowposition].position - transform.position).normalized;
                    _rb.velocity = dir * _moveSpeed;
                }
                else
                {
                    _movePointCount++;
                }
            }
            else
            {

                var footSountPoint = GameObject.FindGameObjectsWithTag("FootSound");
                float distance = Vector3.Distance(transform.position, footSountPoint[0].transform.position);
                if (distance > _stopingDistance)
                {
                    transform.LookAt(footSountPoint[footSountPoint.Length - 1].transform.position);
                    Vector3 dir = (footSountPoint[footSountPoint.Length - 1].transform.position - transform.position).normalized;
                    _rb.velocity = dir * _moveSpeed;
                }
            }
        }
    }
}
