using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreate : MonoBehaviour
{
    [SerializeField] GameObject _createObject;
    BoxCollider _boxCollider;
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(FindObjectsOfType<EnemyController>().Length < 30)
        {
            float x = Random.Range(_boxCollider.size.x / 2, -_boxCollider.size.x / 2);
            float y = Random.Range(_boxCollider.size.y / 2, -_boxCollider.size.y / 2);
            float z = Random.Range(_boxCollider.size.z / 2, -_boxCollider.size.z / 2);
            Vector3 createPosition = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
            Instantiate(_createObject, createPosition, transform.rotation);
        }
    }
}
