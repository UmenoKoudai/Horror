using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour, IAction
{
    [SerializeField] string _open;
    [SerializeField] string _close;
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
            _anim.Play(_open);
        }
        else
        {
            _anim.Play(_close);
        }
        _isDoorOpen = !_isDoorOpen;
    }
}
