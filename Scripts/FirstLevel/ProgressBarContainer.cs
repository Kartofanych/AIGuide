using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarContainer : MonoBehaviour
{
    [Header("UI Elements")] 
    [SerializeField]
    private Image _image;
    [Header("Propeties")] 
    [SerializeField] private int value;
    [SerializeField] private int maxValue = 3;
    [Header("Children")] [SerializeField] private Text _procents;
    
    // Start is called before the first frame update

    
    private void LateUpdate()
    {
        _image.fillAmount = (float) value / maxValue;
    }

    public void SetValue(int value)
    {
        this.value = value;
        _procents.text = Math.Round((float) value / maxValue * 100, 1) + "%";
    }

    public void SetMaxValue(int maxValue) => this.maxValue = maxValue;
    


}
