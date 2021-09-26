using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{

    private void Start()
    {
    }

    private void OnMouseDown()
    {
        gameObject.GetComponentInParent<Panel>().Destroying();
    }

}
