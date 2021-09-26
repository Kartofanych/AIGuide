using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLevels : MonoBehaviour
{

    [SerializeField] private GameObject _levelHolder;
    [SerializeField] private GameObject _holder;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        _levelHolder.SetActive(true);
        _holder.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Start()
    {
    }

    public void Congrats()
    {
        _levelHolder.SetActive(false);
        _holder.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
