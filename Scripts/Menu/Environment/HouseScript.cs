using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int _houseNum;
    [SerializeField] private Sprite[] _sprites;
    private BoxCollider2D _coll;
    void Start()
    {
        _coll = GetComponent<BoxCollider2D>();
        if (!PlayerPrefs.HasKey("Point") || PlayerPrefs.GetInt("Point").Equals(1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[0];
            _coll.size = new Vector2(3.5f, 3.8f);
            _coll.offset = new Vector2(-0.5f, 0.3f);
            transform.position = new Vector3(-8.8f, -1.46f);
        }
        else if (PlayerPrefs.GetInt("Point").Equals(2))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[1];
            _coll.size = new Vector2(5.4f, 4.5f);
            _coll.offset = new Vector2(-0.26f, 0.25f);
            transform.position = new Vector3(-9.55f, -1.45f);
        }else if (PlayerPrefs.GetInt("Point").Equals(3))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[2];
            _coll.size = new Vector2(8f, 4.85f);
            _coll.offset = new Vector2(-0.11f, 0.1f);
            transform.position = new Vector3(-10.4f, -0.7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
