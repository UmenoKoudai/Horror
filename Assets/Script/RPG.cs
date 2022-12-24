using UnityEngine;

public class RPG : WeaponBase
{
    [SerializeField, Tooltip("弾が発射する場所")] Transform _muzzle;
    //[SerializeField, Tooltip("弾のオブジェクト")] GameObject _bulletObject;
    public override void Action()
    {
        GameObject bullet = (GameObject)Resources.Load("Rocket");
        Instantiate(bullet, transform.position, transform.rotation);
    }
    //private void Update()
    //{
    //    if (NowBulletCount == 0)
    //    {
    //        _bulletObject.SetActive(false);
    //    }
    //    else
    //    {
    //        _bulletObject.SetActive(true);
    //    }
    //}
}
