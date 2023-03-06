using UnityEngine;

public class Grave : EnemyBase
{
    [SerializeField] GameObject _crashGrave;
    [SerializeField] GameObject _keyItem;
    int _count;
    void Update()
    {
        if(base.HP < 0 && _count == 0)
        {
            Instantiate(_crashGrave, transform.position, transform.rotation);
            Instantiate(_keyItem, new Vector3(transform.position.x, -5.4f, transform.position.z), transform.rotation);
            _count++;
            Destroy(gameObject, 0.5f);
        }
    }
}
