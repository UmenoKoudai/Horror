using UnityEngine;
using System;

public class WeaponAction : MonoBehaviour,IAction
{
    public void Action()
    {
        GameObject[] weapons = PlayerController.Instance.Weapons;
        PlayerController.Instance.Weapons.WeaponChange(Array.FindIndex(weapons, i => i.name == gameObject.name + "(P)"));
    }
}
