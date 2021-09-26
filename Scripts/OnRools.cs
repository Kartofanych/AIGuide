using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private GameObject Rools;
    private void OnMouseDown()
    {
        Rools.SetActive(true);
    }

    public void OnClose()
    {
        Rools.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
