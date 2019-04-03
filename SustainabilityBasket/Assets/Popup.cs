using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using UnityEngine.EventSystems;
using UnityEngine.UI.CoroutineTween;
using TMPro;
using UnityEngine.Assertions;

public class Popup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI eventName;
    [SerializeField] private TextMeshProUGUI eventDescription;

    [SerializeField] private List<SliderBar> sliderBars;
    private float maxValue = 0;

    public string EventName {
        get { return eventName.text; }
        set { eventName.text = value; }
    }
    public string EventDescription {
        get { return eventDescription.text; }
        set { eventDescription.text = value; }
    }

    public float SliderMax {
        get { return sliderBars[0].Slider.maxValue; }
        set
        {
            foreach(SliderBar sliderBar in sliderBars)
            {
                sliderBar.Slider.maxValue = value;
            }
        }
    }
    public Color SliderColor { 
        get { return sliderBars[0].FillImage.color; }
        set
        {
            foreach (SliderBar sliderBar in sliderBars)
            {
                sliderBar.FillImage.color = value;
            }
        }
    }

    void Awake()
    {
        Assert.IsNotNull(eventName);
        Assert.IsNotNull(eventDescription);
        Assert.IsNotNull(sliderBars[0]);

        maxValue = SliderMax;
        foreach(SliderBar sliderBar in sliderBars)
        {
            sliderBar.Slider.onValueChanged.AddListener(CheckSlider);
        }
    }

    private void CheckSlider(float newVal)
    {
        float total = 0;
        foreach(SliderBar sliderBar in sliderBars)
        {
            total += sliderBar.Slider.value;
        }
        SliderColor = (total > maxValue) ? Color.red : Color.green;
        SetSliderText();
    }

    private void SetSliderText()
    {
        foreach(SliderBar sliderBar in sliderBars)
        {
            sliderBar.Text.text = sliderBar.Slider.value.ToString();
        }
    }

    [System.Serializable]
    public class SliderBar
    {
        public Slider Slider;
        public TextMeshProUGUI Text;
        public Image FillImage;
    }
}


