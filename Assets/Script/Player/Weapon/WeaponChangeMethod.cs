using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class WeaponChangeMethod
{
    /// <summary>
    /// GameObject[]型の武器やアイテムの配列で引数にインデックスを渡したら選んだ武器以外をfalseにして選んだ武器をtrueにする
    /// </summary>
    /// <param name="weapons"></param>
    /// <param name="index"></param>
    public static void WeaponChange(this GameObject[] weapons, string weaponName)
    {
        int index = Array.FindIndex(weapons, i => i.name == weaponName);
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }
    /// <summary>
    /// GameObject[]型の武器やアイテムの配列で引数にインデックスを渡したら選んだ武器以外をfalseにして選んだ武器をtrueにする
    /// </summary>
    /// <param name="weapons"></param>
    /// <param name="index"></param>
    public static void WeaponChange(this GameObject[] weapons, int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }
    /// <summary>
    /// List<GameObject>型の武器やアイテムのリストで引数にインデックスを渡したら選んだ武器以外をfalseにして選んだ武器をtrueにする
    /// </summary>
    /// <param name="weapons"></param>
    /// <param name="index"></param>
    public static void WeaponChange(this List<GameObject> weapons, int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);
    }
}