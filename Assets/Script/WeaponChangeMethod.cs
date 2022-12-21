using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class WeaponChangeMethod
{
    /// <summary>
    /// GameObject[]�^�̕����A�C�e���̔z��ň����ɃC���f�b�N�X��n������I�񂾕���ȊO��false�ɂ��đI�񂾕����true�ɂ���
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
    /// GameObject[]�^�̕����A�C�e���̔z��ň����ɃC���f�b�N�X��n������I�񂾕���ȊO��false�ɂ��đI�񂾕����true�ɂ���
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
    /// List<GameObject>�^�̕����A�C�e���̃��X�g�ň����ɃC���f�b�N�X��n������I�񂾕���ȊO��false�ɂ��đI�񂾕����true�ɂ���
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