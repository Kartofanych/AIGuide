using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseClick : MonoBehaviour
{
    public Camera Cam;
    [SerializeField] private int HouseNum = 0;

    public GameObject ListOfClans, ListOfTasks;
    public int point = 1;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(CheckClick());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator CheckClick()
    {
        yield return new WaitForSeconds(0.11f);
        if (Cam.GetComponent<CameraController>()._isDragged == false)
        {
            if (HouseNum == 1)
            {
                Cam.GetComponent<CameraScript>().state = 1;
            }
            else if (HouseNum == 2)
            {
                Cam.GetComponent<CameraScript>().state = 2;
            }
            else if (HouseNum == 3)
            {
                Cam.GetComponent<CameraScript>().state = 3;
            }
        }
    }
}
