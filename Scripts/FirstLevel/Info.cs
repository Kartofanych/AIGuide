using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    
    public Text _money, _name, level; 
    // Start is called before the first frame update
    void Start()
    {
        UpdateInfo();
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
    public async Task UpdateInfo() 
    {
        level.text = PlayerPrefs.GetInt("Level").ToString();
        _money.text = PlayerPrefs.GetInt("Money").ToString();
        _name.text = PlayerPrefs.GetString("Name");
        
        
        PostMoney postMoney = new PostMoney();
        postMoney.id = PlayerPrefs.GetInt("id");
        postMoney.name = PlayerPrefs.GetString("Name");
        postMoney.budget = PlayerPrefs.GetInt("Money");
        
        string json = JsonUtility.ToJson(postMoney);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        HttpResponseMessage response = await client.PostAsync(new Uri("http://62.84.118.136:8080/update_budget"), httpContent);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var data = JsonUtility.FromJson<PostMoney>(responseBody);
        Debug.Log(responseBody.ToString() + data);
    }
    // Update is called once per frame
    void Update()
    {
        /*_money.text = "Money: " +  (Money + 1000).ToString();
        level.text = "Level: " +  (_level ).ToString();
        */
    }
}
