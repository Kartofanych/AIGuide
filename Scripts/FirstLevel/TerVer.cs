using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerVer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int _level;
    public GameObject _panel;
    private Vector2 pos = new Vector2(0, 0);
    void Start()
    {
        
        _level = GetComponentInParent<Levels>()._level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameObject.Find("Into").transform.childCount < 1)
        {
            var _crPanel = Instantiate(_panel, pos, Quaternion.identity);
            _crPanel.transform.SetParent(GameObject.Find("Into").transform);
            if (gameObject.tag.Equals("Zad"))
            {
                _crPanel.GetComponent<Panel>().CreatingExes(_level+1, gameObject.transform.position);
                _crPanel.GetComponent<Panel>()._level = _level+1;
            }
            else
            {
                _crPanel.GetComponent<Panel>()._level = _level+1;
                _crPanel.GetComponent<Panel>().CreatingStates(_level+1, gameObject.transform.position);
            }
            
        }
    }
}
