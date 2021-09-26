using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder4 : MonoBehaviour
{ // Start is called before the first frame update
    public int _level;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector2 _levelPos;
    private GameObject _holder;
    private GameObject Garage;
    void Start()
    {
        _holder = GameObject.Find("LevelsInto");
        Garage = GameObject.Find("Garage_inside");
        _level = PlayerPrefs.GetInt("Level") - 1;
        UpdateLevels();
    }

    public void UpdateLevels()
    {
        for (int i = 0; i < _level; i++)
        {
            var myNewSmoke = Instantiate(_prefab, _levelPos, Quaternion.identity);
            _levelPos.y -= 1f;
            myNewSmoke.GetComponent<Levels>()._level = i;
            myNewSmoke.transform.parent = _holder.transform;
        }
        
        
        
        
    }

}