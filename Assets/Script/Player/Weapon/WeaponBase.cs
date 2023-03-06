using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]float _intarval;
    [SerializeField] int _maxBulletCount;
    [SerializeField] Text _bulletCounttext;
    [SerializeField] GameObject _panel;
    float _timer;
    int _nowBulletCount;

    public int NowBulletCount { get; }

    public abstract void Action();

    void Update()
    {
        _timer += Time.deltaTime;
        _bulletCounttext.text = $"{_maxBulletCount - _nowBulletCount}/{_maxBulletCount}";
        if (_intarval < _timer && _nowBulletCount != _maxBulletCount)
        {
            if (Input.GetButton("Fire1"))
            {
                AudioController.Instance.SePlay(SelectClip.Shoot, 0f);
                Action();
                _timer = 0;
                GameObject sound = (GameObject)Resources.Load("FootSound");
                Instantiate(sound, new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);
                _panel.transform.GetChild(_nowBulletCount).gameObject.SetActive(false);
                _nowBulletCount++;
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && !Input.GetButton("Fire1"))
        {
            AudioController.Instance.SePlay(SelectClip.Reload, 0.5f);
            _nowBulletCount = 0;
            for(int i = 0; i < _panel.transform.childCount; i++)
            {
                _panel.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
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
        var hitEnemy = enemyCollider.GetComponentInChildren<EnemyBase>();
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
