using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseMe : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            if (GameObject.Find("LevelsInto") != null)
            {
                GameObject.Find("LevelsInto").SetActive(false);
            }

            GameObject.Find("Canvas_1").SetActive(false);
            GameObject.Find("Garage_inside").GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
