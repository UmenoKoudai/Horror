using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [ContextMenuItem("Random", "RandomNum")]
    [ContextMenuItem("Reset", "ResetNum")]
    [SerializeField] int num;
    [SerializeField] int n;
    void RandomNum()
    {
        num = Random.Range(0, 101);
    }
    void ResetNum()
    {
        num = 0;
    }
}
