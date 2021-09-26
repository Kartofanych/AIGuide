using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextFactory : MonoBehaviour
{
    [Header("Fonts")] [SerializeField] private Font[] _font;
    public String txt;
    // т.к. загрузка занимает какое-то время, то используется сопрограмма, позволяющая
    // вернуться к выполнению метода после завершения WWW запроса
    // все сопрограммы в C# имеют тип возвращаемого значения - IEnumerator

    public Text CreateText(string text, Transform parent, int size, int FontNum)
    {
        var empty = new GameObject();
            empty.transform.SetParent(parent);
            empty.transform.localScale = Vector3.one;
            var textComponent = empty.AddComponent<Text>();
            textComponent.text = text;
            textComponent.fontStyle = FontStyle.Normal;
            textComponent.font = _font[FontNum];
            textComponent.color = Color.black;
            textComponent.fontSize = size;
            txt = text;
            textComponent.AddComponent<WebHttp>();
            //Instantiate(empty, parent.transform.position, Quaternion.identity);
            return textComponent;
    }
    public Image CreateImage(string text, Transform parent, int size, int FontNum)
    {
        var empty = new GameObject();
            empty.transform.SetParent(parent);
            empty.transform.localScale = new Vector3(1, 10, 1);
            var textComponent = empty.AddComponent<Image>();
            Debug.Log(text);
            var webClient = new WebClient();
            var imageBytes = webClient.DownloadData(text);
            Texture2D tex = new Texture2D(1,1); // note that the size is overridden
            tex.LoadImage(imageBytes);
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width, tex.height));
            textComponent.sprite = sprite;
            return textComponent;
    }
}
