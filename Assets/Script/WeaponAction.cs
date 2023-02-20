using UnityEngine;
using System;

public class WeaponAction : MonoBehaviour,IAction
{
    public void Action()
    {
        PlayerController _player = FindObjectOfType<PlayerController>();
        _player.Weapons.WeaponChange(Array.FindIndex(_player.Weapons, i => i.name == _player.HitObject.name));
    }
}
