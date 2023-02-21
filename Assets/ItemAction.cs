using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour, IAction
{
    public void Action()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        GameObject obj = GameObject.Find(this.gameObject.name + "Icon").transform.GetChild(0).gameObject;
        obj.SetActive(true);
    }
}
