using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponBase : MonoBehaviour
{
    public static float _intarval;
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

    public static void IntarvalUpdate(float interval)
    {
        _intarval = interval;
    }
    /// <summary>
    /// 弾が当たった位置にエフェクトを自分に向けて発生させる
    /// </summary>
    /// オブジェクトをインスタンスする位置
    /// <param name="endLine"></param>
    /// 回転させる方向
    /// <param name="hitAngle"></param>
    /// 弾を飛ばした方向
    /// <param name="startAngle"></param>
    /// 発生させたいエフェクト
    /// <param name="effect"></param>
    public static void HitEffect(Vector3 endLine, Vector3 hitAngle, Vector3 startAngle,GameObject effect)
    {
        Instantiate(effect, endLine, Quaternion.FromToRotation(startAngle, hitAngle));
    }

    /// <summary>
    /// Rayが当たったエネミーのスクリプトにあるダメージ関数を実行する
    /// </summary>
    /// ヒットしたエネミーのコライダー
    /// <param name="enemyCollider"></param>
    /// エネミーに与えるダメージ量
    /// <param name="gunPower"></param>
    /// 
    public static void HitAction(Collider enemyCollider, int gunPower)
    {
        var hitEnemy = enemyCollider.GetComponent<EnemyController>();
        hitEnemy.Damage(gunPower);
    }

    /// <summary>
    /// エネミーに弾がヒットした時クロスヘアの色を変える
    /// </summary>
    /// 色を変えたいクロスヘアの画像
    /// <param name="crosshair"></param>
    /// 当たった時の色
    /// <param name="afterColor"></param>
    /// 通常の色
    /// <param name="beforeColor"></param>
    /// <returns></returns>
    public static IEnumerator CrosshairColorChange(Image crosshair, Color afterColor, Color beforeColor)
    {
        crosshair.color = beforeColor;
        yield return new WaitForSeconds(0.3f);
        crosshair.color = afterColor;
    }
}
