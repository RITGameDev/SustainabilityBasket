using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicePopupArea : MonoBehaviour
{
    [SerializeField]
    private MajorEventDetails events;
    [SerializeField]
    private ChoicePopup choicePopup;

    public void DisplayChoices(int currentEvent)
    {
        for (int i = 0; i < events.majorEvents[currentEvent].choices.Count; i++)
        {
            ChoicePopup newChoice = Instantiate(choicePopup, gameObject.transform);
            newChoice.CreatePopup(events.majorEvents[currentEvent].choices[i]);
        }
    }
}
