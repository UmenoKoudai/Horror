using UnityEngine;

public class RPG : WeaponBase
{
    [SerializeField, Tooltip("�e�����˂���ꏊ")] Transform _muzzle;
    //[SerializeField, Tooltip("�e�̃I�u�W�F�N�g")] GameObject _bulletObject;
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
