using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Seth Leyens
/// Script for handling the timeline at the bottom of the screen
/// </summary>
public class Timeline : MonoBehaviour
{
    #region Public Variables
    public int numberOfRounds;
    public Vector2Int startDate;
    public Vector2Int endDate;
    public Slider timelineSlider;
    public Image timeMarkPrefab;
    public GameObject timeMarkParent;
    #endregion

    #region Class Variables
    private List<Image> timeMarks;
    private int currentLocation = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timeMarks = new List<Image>();

        //Calculate the spacing to use for the timeline markers
        float interval = timelineSlider.GetComponent<RectTransform>().rect.width / numberOfRounds;

        //Instantiate the markers
        for(int i = 0; i < numberOfRounds; i++)
        {
            Image temp = Instantiate(timeMarkPrefab, timeMarkParent.transform);
            temp.rectTransform.position = new Vector3((interval * (i + 1)) - temp.rectTransform.rect.width, timelineSlider.transform.position.y, timelineSlider.transform.position.z);
            timeMarks.Add(temp);
        }
    }

    /// <summary>
    /// Coroutine used for moving the timeline slider
    /// </summary>
    /// <returns>null</returns>
    IEnumerator MoveTimeline()
    {
        //Increment the current location variable
        currentLocation++;

        //Determine where from 0 - 1 the slider needs to move to
        float timeDelta = 0.0f;
        float targetPosition = (1.0f / numberOfRounds) * currentLocation;

        //Loop until we are done
        while(timeDelta <= 1)
        {
            timelineSlider.value = Mathf.Lerp(timelineSlider.value, targetPosition, timeDelta);
            timeDelta += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// Public method called to trigger the MoveTimeline coroutine
    /// </summary>
    public void TriggerTimeline()
    {
        StartCoroutine(MoveTimeline());
    }
}
