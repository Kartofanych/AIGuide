using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Category
{
    public int id;
    public string title;
    public DateTime created_at;
    public DateTime updated_at;
    public int clues_count;
}

[Serializable]
public class Root
{
    public int id;
    public string answer;
    public string question;
    public int value;
    public DateTime airdate;
    public DateTime created_at;
    public DateTime updated_at;
    public int category_id;
    public object game_id;
    public object invalid_count;
    public Category category;
}



public class Request_Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Get();
    }
    public void Get()
    {
        HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create("https://jservice.io/api/random");

        request.Method = "GET";
        request.Accept = "application/json";
        request.UserAgent = "Mozilla/5.0 ....";

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        StringBuilder output = new StringBuilder();
        output.Append(reader.ReadToEnd());
        Debug.Log(output);
        response.Close();
        output.Replace("[","");
        output.Replace("]","");
        var data = JsonUtility.FromJson<Root>(output.ToString());
        Debug.Log(data.id);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
