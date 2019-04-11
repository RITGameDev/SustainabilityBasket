using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventChoice : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI choiceName;
    [SerializeField]
    private TextMeshProUGUI statChanges;
    [SerializeField]
    private MajorEventDetails events;

    public string ChoiceName
    {
        get { return choiceName.text; }
        set { choiceName.text = value; }
    }

    public string StatChanges
    {
        get { return statChanges.text; }
        set { statChanges.text = value; }
    }
}
