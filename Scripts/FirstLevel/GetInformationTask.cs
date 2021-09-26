using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetInformationTask : MonoBehaviour
{
    [Serializable]
    public class TutorPost
    {
        public string topic;
        public int tutorial_id;
    }
    [Serializable]
    public class Task_Answer
    {
        public List<string> questions;
        public List<List<string>> options;
        public List<int> answers;

    }
    
    public string[,] optionss = new string[3,3];
    public int[] ans = new int[3];
    void Start()
    {
        Get();
    }

    [SerializeField] private GameObject Prefab_Task;
    static HttpClient client = new HttpClient();
    [SerializeField] private Text _info, _name;
    
    public async Task Get()
    {
        int id = 0;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            id = gameObject.GetComponent<Panel>()._level;
        }else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            id = gameObject.GetComponent<Panel2>()._level;
        }else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            id = gameObject.GetComponent<Panel3>()._level;
        }

        TutorPost post = new TutorPost();
        post.topic = "Basic ML";
        post.tutorial_id = id;
        string json = JsonUtility.ToJson(post);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        
        HttpResponseMessage response = await client.PostAsync(new Uri("http://62.84.118.136:8080/tests"), httpContent);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var data = JsonUtility.FromJson<Task_Answer>(responseBody);
        for (int i = 0; i < data.questions.Count; i++)
        {
            var gameObjec =  Instantiate(Prefab_Task, new Vector3(0f,0f,0f), Quaternion.identity);
            gameObjec.GetComponentInChildren<Text>().text = data.questions[i];
            gameObjec.transform.SetParent(GameObject.Find("Holder").transform);
        }

        for (int i = 0; i < data.options.Count; i++)
        {
            for (int j = 0; j < data.options[i].Count; j++)
            {
                optionss[i,j] = data.options[i][j];
            }
        }
        for (int j = 0; j < data.answers.Count; j++)
        {
            ans[j] = data.answers[j];
        }
        //_name.text = data.questions[0];
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
