using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel3 : MonoBehaviour
{
     // Start is called before the first frame update
    public int _level;
    [SerializeField] private Text _name, _info;
    [SerializeField] private GameObject _submit;
    void Start()
    {
        _level = PlayerPrefs.GetInt("Level")-6;
    }

    // Update is called once per frame
    public void CreatingExes(int level, Vector3 posit)
    {        
        _level = PlayerPrefs.GetInt("Level")-6;
        Debug.Log(_level + " " + level);
        if (_level-1 == level-6)
        {
            _submit.gameObject.SetActive(true);
        }
        else
        {
            _submit.gameObject.SetActive(false);
        }
        gameObject.transform.position = posit;
        _name.text = level.ToString();

    }
    public void CreatingStates(int level, Vector3 posit)
    {        
        _level = PlayerPrefs.GetInt("Level")-3;
        Debug.Log(_level + " " + level);
        gameObject.transform.position = posit;
        _name.text = level.ToString();

    }

    public void Destroying()
    {   
        Destroy(gameObject);
    }
    
    public void SubmitIt()
    { 
        int Money = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", Money+100000);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        PlayerPrefs.Save();
        _level = PlayerPrefs.GetInt("Level")-6;
        Destroying();
        GameObject.Find("AllLevels").GetComponent<LevelHolder3>().UpdateLevels();
    }
}
