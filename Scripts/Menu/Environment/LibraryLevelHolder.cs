using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryLevelHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int level;
    void Start()
    {
        if (level + 1 > PlayerPrefs.GetInt("Level"))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
