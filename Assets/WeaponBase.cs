using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponBase : MonoBehaviour
{
    float _intarval = 0.1f;
    float _timer;
    public abstract void Action();

    void Update()
    {
        _timer += Time.deltaTime;
        Debug.Log(_timer);
        if (_intarval < _timer)
        {
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("shoot");
                Action();
                _timer = 0;
            }
        }
    }
    //public void HitEffect(Vector3 endLine, Vector3 hitAngle, GameObject effect)
    //{
    //    Instantiate(effect, endLine, Quaternion.FromToRotation(transform.forward, hitAngle));
    //}

    //public void HitAction(Collider enemyCollider, int gunPower)
    //{
    //    var hitEnemy = enemyCollider.GetComponent<EnemyController>();
    //    hitEnemy.Damage(gunPower);
    //}

    //public IEnumerator CrosshairColorChange(Image crosshair, Color afterColor, Color beforeColor)
    //{
    //    crosshair.color = beforeColor;
    //    yield return new WaitForSeconds(0.3f);
    //    crosshair.color = afterColor;
    //}
}
