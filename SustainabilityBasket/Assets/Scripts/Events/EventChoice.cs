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

    public TextMeshProUGUI ChoiceName
    {
        get { return choiceName; }
        set { choiceName = value; }
    }

    public TextMeshProUGUI StatChanges
    {
        get { return statChanges; }
        set { statChanges = value; }
    }
}
