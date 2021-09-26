using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CameraScript : MonoBehaviour
{
    public Transform house1, house2, house3;
    //private Vector3 FirstPosition;
    private double TOLERANCE = 0.05f;
    public Image Black;

    public int state = 0;
    private Camera Cam;
    
    
    private float speed = 0.00225f; 
    void Start()
    {
        Cam = Camera.main;
//        FirstPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (state == 1)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, house1.position, speed);
            StartCoroutine(NextActivity());
            if (Black.color.a < 1f)
            {
                Black.color = new Color(Black.color.r, Black.color.g, Black.color.b,
                    Black.color.a + 1f * Time.deltaTime);
            }

        }
        if (state == 2)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, house2.position, speed);
            StartCoroutine(NextActivity());
            if (Black.color.a < 1f)
            {
                Black.color = new Color(Black.color.r, Black.color.g, Black.color.b,
                    Black.color.a + 1f * Time.deltaTime);
            }

        }
        if (state == 3)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, house3.position, speed);
            StartCoroutine(NextActivity());
            if (Black.color.a < 1f)
            {
                Black.color = new Color(Black.color.r, Black.color.g, Black.color.b,
                    Black.color.a + 1f * Time.deltaTime);
            }

        }
        
        

        
    }
    // Update is called once per frame

    IEnumerator NextActivity()
    {
        yield return new WaitForSeconds(1.5f);
        string next = null;
        if (state == 1)
        {
            next = "Level" + PlayerPrefs.GetInt("Point");
        }else if (state == 3)
        {
            next = "Library";
        }else if (state == 2)
        {
            next = "Events";
        }

        SceneManager.LoadScene(next);
        
    }
}
