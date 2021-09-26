using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    private Image img;
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (img.color.a > 0f)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - 0.5f * Time.deltaTime);
        }

        if (img.color.a <= 0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
        }
        
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
