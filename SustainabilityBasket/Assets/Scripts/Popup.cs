using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Popup : MonoBehaviour
{
    #region fields and properties

    [SerializeField] private TextMeshProUGUI eventName; //ref to the event name text
    [SerializeField] private TextMeshProUGUI eventDescription; //ref to the event description text

    [SerializeField] private List<SliderBar> sliderBars; //ref to the slider bars
    [SerializeField] private float maxValue = 10; //maximum spending value

    [SerializeField] private MajorEventDetails events;

    private string EventName {
        get { return eventName.text; }
        set { eventName.text = value; }
    }
    private string EventDescription {
        get { return eventDescription.text; }
        set { eventDescription.text = value; }
    }
    private float SliderMax {
        get { return sliderBars[0].Slider.maxValue; }
        set
        {
            foreach(SliderBar sliderBar in sliderBars)
            {
                sliderBar.Slider.maxValue = value;
            }
        }
    }
    private Color SliderColor { 
        get { return sliderBars[0].FillImage.color; }
        set
        {
            foreach (SliderBar sliderBar in sliderBars)
            {
                sliderBar.FillImage.color = value;
            }
        }
    }

    #endregion

    void Awake()
    {
        SliderMax = maxValue;
        foreach(SliderBar sliderBar in sliderBars)
        {
            sliderBar.Slider.onValueChanged.AddListener(CheckSlider);
        }
        ResetSliders();
        SliderColor = Color.green;
    }

    public void TextCall()
    {
        if (events.majorEvents.Count == 0)
        {
            StartNewEvent("Test Event", "Called by the Next Event button", 100);
        }
        else
        {
            EventName = events.majorEvents[0].eventName;
            EventDescription = events.majorEvents[0].eventDescription;
        }
    }

    public void StartNewEvent(string eventName, string eventDescription, float totalFunds )
    {
        EventName = eventName;
        EventDescription = eventDescription;

        SliderMax = totalFunds;
        ResetSliders();
    }

    #region Helper methods

    /// <summary>
    /// sets the values of all the sliders to zero
    /// </summary>
    private void ResetSliders()
    {
        foreach (SliderBar sliderBar in sliderBars)
        {
            sliderBar.Slider.value = 0;
        }
        SliderColor = Color.green;
    }

    /// <summary>
    /// called when the slider value is changed
    /// </summary>
    /// <param name="newVal">unused value of slider</param>
    private void CheckSlider(float newVal)
    {
        float total = 0;
        foreach (SliderBar sliderBar in sliderBars)
        {
            total += sliderBar.Slider.value;
        }
        SliderColor = (total > maxValue) ? Color.red : Color.green;
        SetSliderText();
    }
    /// <summary>
    /// set the text for all the sliders
    /// </summary>

    private void SetSliderText()
    {
        foreach(SliderBar sliderBar in sliderBars)
        {
            sliderBar.Text.text = sliderBar.Slider.value.ToString();
        }
    }

    #endregion

    [System.Serializable]
    public class SliderBar
    {
        public Slider Slider;
        public TextMeshProUGUI Text;
        public Image FillImage;
    }
}


