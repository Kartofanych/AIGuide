using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    // Start is called before the first frame update
    public int _level;
    [SerializeField] private Text _name, _info;
    [SerializeField] private GameObject _submit;
    [SerializeField] private GameObject _Buttons;
    void Start()
    {
    }

    public GameObject aans;
    // Update is called once per frame
    public void Answers()
    {
        Debug.Log("hey");
        string str = "";
        for (int i = 0; i < gameObject.GetComponent<GetInformationTask>().ans.Length; i++)
        {
            str += "\r\n" + gameObject.GetComponent<GetInformationTask>().ans[i];
        }

        aans.GetComponent<Text>().text = str;
        aans.SetActive(true);
    }
    public void CreatingExes(int level, Vector3 posit)
    {
        if (PlayerPrefs.GetInt("Level") == level)
        {
            _submit.gameObject.SetActive(true);
        }
        else
        {
            _submit.gameObject.SetActive(false);
        }

    }
    public void CreatingStates(int level, Vector3 posit)
    {        
        gameObject.transform.position = posit;
        _name.text = level.ToString();

    }

    public void Destroying()
    {   
        Destroy(gameObject);
    }

    /*public int[] ans = new int[3];
    private int[] tag = new int[3];

    
    public void But1()
    {
        tag[0] = 1_1;
    }public void But2()
    {
        tag[0] = 1_2;
    }public void But3()
    {
        tag[0] = 1_3;
    }public void But4()
    {
        tag[1] = 2_1;
    }public void But5()
    {
        tag[1] = 2_2;
    }public void But6()
    {
        tag[1] = 2_3;
    }public void But7()
    {
        tag[2] = 3_1;
    }public void But8()
    {
        tag[2] = 3_2;
    }public void But9()
    {
        tag[2] = 3_3;
    }*/

    public void SubmitIt()
    {
        int Money = PlayerPrefs.GetInt("Money");
        /*int[] _ans = gameObject.GetComponent<GetInformationTask>().ans;
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(tag[i] + " " + _ans[i]);
            if (tag[i] == _ans[i])
            {
                Money += 1000;
            }
        }*/
        
        
        PlayerPrefs.SetInt("Money", Money+1000);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        PlayerPrefs.Save();
        _level = PlayerPrefs.GetInt("Level");
        Destroying();
        GameObject.Find("AllLevels").GetComponent<LevelHolder>().UpdateLevels();
    }
}
