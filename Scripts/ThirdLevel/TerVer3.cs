using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerVer3 : MonoBehaviour
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
    private void OnMouseDown()
    {
        var _crPanel = Instantiate(_panel, pos, Quaternion.identity);
        if (gameObject.tag.Equals("Zad"))
        {
            _crPanel.GetComponent<Panel3>().CreatingExes(_level, gameObject.transform.position);
        }
        else
        {
            _crPanel.GetComponent<Panel3>().CreatingStates(_level, gameObject.transform.position);
        }
    }
}
