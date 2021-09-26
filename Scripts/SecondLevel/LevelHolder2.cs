using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levels;
    private int _level;
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector2 _levelPos;
    private GameObject _holder;
    private GameObject Garage;
    private GameObject ProgressBarCont;
    void Start()
    {
        _holder = GameObject.Find("LevelsInto");
        Garage = GameObject.Find("Garage_inside");
        ProgressBarCont = GameObject.Find("ProgressBarContainer");
        
        _level = PlayerPrefs.GetInt("Level")-3;
        ProgressBarCont.GetComponent<ProgressBarContainer>().SetValue(_level-1);
        Debug.Log(_level);
        UpdateLevels();
    }

    public GameObject _congrats;
    public void UpdateLevels()
    {
        Info.GetComponent<Info>().UpdateInfo();
        if (levels.Length == 0)
        {
            levels = new GameObject[_level];
            for (int i = 0; i < levels.Length; i++)
            {
                var myNewSmoke = Instantiate(_prefab, _levelPos, Quaternion.identity);
                levels[i] = myNewSmoke;
                _levelPos.y -= 1f;
                myNewSmoke.GetComponent<Levels>()._level = i+3;
                myNewSmoke.transform.parent = _holder.transform;
            }
        }else if (PlayerPrefs.GetInt("Level")-3 > 3) {
            ProgressBarCont.GetComponent<ProgressBarContainer>().SetValue(_level-1);
            if (PlayerPrefs.GetInt("Point") < 3)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100000);
                PlayerPrefs.SetInt("Point", 3);
                _congrats.SetActive(true);
                Garage.GetComponent<OpenLevels>().Congrats();
                //Congrats!
            }
        }
        else
        {
            for (int i = 0; i < levels.Length; i++)
            {
                Destroy(levels[i]);
            }
            _level = PlayerPrefs.GetInt("Level")-3;
            ProgressBarCont.GetComponent<ProgressBarContainer>().SetValue(_level-1);
            _levelPos.y = 3f;            
            levels = new GameObject[_level];

            for (int i = 0; i < levels.Length; i++)
            {
                var myNewSmoke = Instantiate(_prefab, _levelPos, Quaternion.identity);
                levels[i] = myNewSmoke;
                _levelPos.y -= 1f;
                myNewSmoke.GetComponent<Levels>()._level = i+3;
                myNewSmoke.transform.parent = _holder.transform;

            }
        }


        
        
    }

}
