using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerVer2 : MonoBehaviour
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
                _crPanel.GetComponent<Panel2>().CreatingExes(_level, gameObject.transform.position);
            }
            else
            {
                _crPanel.GetComponent<Panel2>().CreatingStates(_level, gameObject.transform.position);
            }
        }
    }
}