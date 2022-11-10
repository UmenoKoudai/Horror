using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPosition : MonoBehaviour
{
    void Update()
    {
        var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePoint;
    }
}
