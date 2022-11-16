using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponID : MonoBehaviour
{
    [SerializeField] string _weaponName;
    public int _id;

    private void Start()
    {
        switch (_weaponName)
        {
            case "ShotGun":
                _id = 0;
                break;

            case "AssaultRifle":
                _id = 1;
                break;
        }
    }
}
