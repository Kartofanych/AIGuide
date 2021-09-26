using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetInformation : MonoBehaviour
{
    [Serializable]
    public class TutorPost
    {
        public string topic;
        public int tutorial_id;
    }

    [Serializable]
    public class State
    {
        public string tutorial;
    }
    private string StripMarkdownTags(string content)
    {
        // Headers
        content = Regex.Replace(content, "/\n={2,}/g", "\n");
        // Strikethrough
        content = Regex.Replace(content, "/~~/g", "");
        // Codeblocks
        content = Regex.Replace(content, "/`{3}.*\n/g", "");
        // HTML Tags
        content = Regex.Replace(content, "/<[^>]*>/g", "");
        // Remove setext-style headers
        content = Regex.Replace(content, "/^[=\\-]{2,}\\s*$/g", "");
        // Footnotes
        content = Regex.Replace(content, "/\\[\\^.+?\\](\\: .*?$)?/g", "");
        content = Regex.Replace(content, "/\\s{0,2}\\[.*?\\]: .*?$/g", "");
        // Images
        content = Regex.Replace(content, "/\\!\\[.*?\\][\\[\\(].*?[\\]\\)]/g", "");
        // Links
        content = Regex.Replace(content, "/\\[(.*?)\\][\\[\\(].*?[\\]\\)]/g", "$1");
        return content;
    }

    // Start is called before the first frame update
    void Start()
    {
        Get();
    }
    static HttpClient client = new HttpClient();
    private GameObject _holder;
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
        Debug.Log("id"+id);
        string json = JsonUtility.ToJson(post);
        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        
        
        HttpResponseMessage response = await client.PostAsync(new Uri("http://62.84.118.136:8080/tutorials"), httpContent);
        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        var data = JsonUtility.FromJson<State>(responseBody);
        //Markdown mark = new Markdown();
        
        string fullTxt = StripMarkdownTags(data.tutorial);
        int count = 0;
        using var sr = new StringReader(fullTxt);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            count++;
        }  
        Listener(count, fullTxt);
        
    }

    private string[] all = null;
    private void Listener(int kol, string str)
    {
        _holder = GameObject.Find("Holder");
        using var sr = new StringReader(str);

        int count = 0;
        string line;
        int j = 0, i = 0;
        all = new string[kol/32+1];
        while ((line = sr.ReadLine()) != null)
        {
            if (j == 0)
            {
                all[i] += "\r\n" +line;
                j++;
            }else
            if (j < 31)
            {
                j++;
                all[i] += "\r\n" +line;
            }
            else
            {
                all[i] += "\r\n" +line;
                j = 0;
                i++;
            }
            _holder = GameObject.Find("Holder");
            if (line.Length == 0)
            {
                
            }else if(line.Contains("http"))
            {
                _holder.GetComponent<TextFactory>().CreateImage(line,_holder.transform, 40, 0);
            }else
            if (line.StartsWith("##"))
            {
                _holder.GetComponent<TextFactory>().CreateText(
                    line.Replace("#", ""),_holder.transform, 40, 0);
                
            }else
            if (line.StartsWith("#"))
            {
                _holder.GetComponent<TextFactory>().CreateText(
                    line.Replace("#", ""),_holder.transform, 35, 0);
                
            }else if (line.Contains("*"))
            {
                _holder.GetComponent<TextFactory>().CreateText(
                    line.Replace("*", ""),_holder.transform, 30, 1);
            }
            else
            { 
                _holder.GetComponent<TextFactory>().CreateText(line, _holder.transform, 30, 2);
            }
            count++;
        }

    }

}