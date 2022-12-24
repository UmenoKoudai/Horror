using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour, IAction
{
    Animator _anim;
    bool _isDoorOpen;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Action()
    {
        if(!_isDoorOpen)
        {
            _anim.Play("Open");
        }
        else
        {
            _anim.Play("Close");
        }
        _isDoorOpen = !_isDoorOpen;
    }
}
