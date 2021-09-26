using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaitingAlll : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _money, _name, level;
    private List<PostMoney> _all = new List<PostMoney>();
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _prefab;
    void Start()
    {
        Get();
    }
    [Serializable]
    public class Root
    {
        public List<PostMoney> all;
    }

    [Serializable]
    public class PostMoney
    {
        public int id;
        public string name;
        public int budget;
    }
    static HttpClient client = new HttpClient();
    public async Task Get() 
    {
        level.text = PlayerPrefs.GetInt("Level").ToString();
        _money.text = PlayerPrefs.GetInt("Money").ToString();
        _name.text = PlayerPrefs.GetString("Name");
        
        HttpResponseMessage response = await client.GetAsync(new Uri("http://62.84.118.136:8080/top"));
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Debug.Log(responseBody.ToString());
        var data = JsonUtility.FromJson<Root>(responseBody);
        for (int i = data.all.Count-1; i >= 0; i--)
        {
            PostMoney post = new PostMoney();
            post.budget = data.all[i].budget;
            post.id = data.all[i].id;
            post.name = data.all[i].name;
            _all.Add(post);
        }

        CreateIt();
    }
    private void CreateIt()
    {
        float height = 3f;
        for (int i = _all.Count-1; i >= 0; i--)
        {
            var gameOmj = Instantiate(_prefab, new Vector3(-5.7f,height,0f), Quaternion.identity);
            gameOmj.GetComponent<RaitInside>().UpdateInfo(_all.Count-i, _all[i].id, _all[i].name, _all[i].budget);
            gameOmj.transform.SetParent(_content.transform);
            height -= 1f;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Update()
    {
        
    }
}
