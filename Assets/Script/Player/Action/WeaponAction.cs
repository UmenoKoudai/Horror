using UnityEngine;
using System;

public class WeaponAction : MonoBehaviour,IAction
{
    public void Action()
    {
        PlayerController.Instance.Weapons.WeaponChange(Array.FindIndex(PlayerController.Instance.Weapons, i => i.name == PlayerController.Instance.HitObject.name));
    }
}
