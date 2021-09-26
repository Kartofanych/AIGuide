using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class SharedPreferencesSaver : MonoBehaviour
{
    [Serializable]
    public class PostMoney
    {
        public int id;
        public int money;
    }
    public GameObject createName;

    public Text EditName;
    [SerializeField]
    private GameObject[] Houses;

    private Camera cam;

    public Text Name, Money, Level;

    [SerializeField] private Sprite[] _houseSprites;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (!PlayerPrefs.HasKey("id"))
        {
            
            createName.SetActive(true);
            cam.transform.position = new Vector3(-1f, -5.6f, -10f);
            for (int i = 0; i < Houses.Length; i++)
            {
                Houses[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            Random rnd = new Random();
            int value = rnd.Next(0, 10000000);
            PlayerPrefs.SetInt("id", value);
            PlayerPrefs.SetInt("Money", 1000);
            PlayerPrefs.SetInt("Point", 1);
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
            Debug.Log(value);
            //PostRequest();
        }
        else
        {
            createName.SetActive(false);
            Name.text = PlayerPrefs.GetString("Name");
            Money.text = PlayerPrefs.GetInt("Money").ToString();
            Level.text = PlayerPrefs.GetInt("Level").ToString();
            if (PlayerPrefs.GetInt("Point") == 1)
            {
                Houses[0].GetComponent<HouseClick>().point = 1;
            }else
            if (PlayerPrefs.GetInt("Point") == 4)
            {
                Houses[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void Sceneee()
    {
        SceneManager.LoadScene("Raiting");
    }

    static HttpClient client = new HttpClient();
    private async Task PostRequest()
    {
        PostMoney postMoney = new PostMoney();
        postMoney.id = PlayerPrefs.GetInt("id");
        postMoney.money = PlayerPrefs.GetInt("Money");
        
        string json = JsonUtility.ToJson(postMoney);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        
        HttpResponseMessage response = await client.PostAsync(new Uri("http://62.84.118.136:8080/tutorials"), httpContent);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var data = JsonUtility.FromJson<PostMoney>(responseBody);

    }

    // Update is called once per frame

    public void CloseIt()
    {
        Debug.Log(EditName.text.Length);
        if (EditName.text.Length == 0)
        {
            PlayerPrefs.SetString("Name", "id: " + PlayerPrefs.GetInt("id"));
            Name.text = "id: " + PlayerPrefs.GetInt("id");
        }
        else
        {
            PlayerPrefs.SetString("Name", EditName.text);
            Name.text = EditName.text;
        }

        PlayerPrefs.Save();
        Money.text = PlayerPrefs.GetInt("Money").ToString();
        Level.text = PlayerPrefs.GetInt("Level").ToString();
        createName.SetActive(false);
        
        for (int i = 0; i < Houses.Length; i++)
        {
            Houses[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
    }
}
