using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WebHttp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MouseDown()
    {
        Process.Start(gameObject.GetComponent<TextFactory>().txt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
