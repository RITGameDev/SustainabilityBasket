using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MajorEvents
{
    public string eventName;
    public string eventDescription;
    public List<MajorEventChoices> choices;

    [HideInInspector]
    public bool showChoices = false;
}

[System.Serializable]
public class MajorEventChoices
{
    public string choiceName;
    public List<float> statChanges;
    public List<string> statsToChange;
}

[CreateAssetMenu(fileName = "MajorEvents", menuName = "Major Events Details")]
public class MajorEventDetails : ScriptableObject
{
    public List<MajorEvents> majorEvents = new List<MajorEvents>();
}
