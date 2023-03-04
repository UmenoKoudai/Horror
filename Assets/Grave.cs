using UnityEngine;

public class Grave : EnemyBase
{
    [SerializeField] GameObject _crashGrave;
    [SerializeField] GameObject _keyItem;
    void Update()
    {
        if(base.HP < 0)
        {
            Instantiate(_crashGrave, transform.position, transform.rotation);
            //Instantiate(_keyItem, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnDestroy()
    {
        Instantiate(_keyItem, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
    }
}
