using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventEditor : ScriptableObject
{
    public string windowTitle;
    public Rect windowRect;

    string eventName;
    string eventDescription;
    List<ChoiceEditor> choices;

    public EventEditor()
    {
        eventName = "New Event";
        windowTitle = eventName;
        eventDescription = "Description";
        choices = new List<ChoiceEditor>();
    }

    public void DrawWindow()
    {
        eventName = EditorGUILayout.TextField(eventName);
        eventDescription = EditorGUILayout.TextArea(eventDescription);
    }
}

public class ChoiceEditor : ScriptableObject
{
    // For choices
    string choiceName;
    List<int> changeStatBy;
    List<CityData> statsToChange;

    Vector2 scrollPos;

    enum CityData
    {
        money,
        powerRequired,
        powerSupplied,
        AQI,
        costOfLiving,
        employmentRate,
        population
    }

    public ChoiceEditor()
    {
        choiceName = "Input Name Here";
        changeStatBy = new List<int>();
        statsToChange = new List<CityData>();
    }

    public void DrawWindow()
    {
        if (GUILayout.Button("Add Stat Change"))
        {
            changeStatBy.Add(0);
            statsToChange.Add(CityData.money);
        }

        EditorGUI.LabelField(new Rect(10, 65, 30, 25), "Stat Change");
        EditorGUI.LabelField(new Rect(45, 65, 95, 25), "Stat To Change");

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);
        for (int i = 0; i < changeStatBy.Count; i++)
        {
            changeStatBy[i] = EditorGUI.IntField(new Rect(5, 25 + i * 25, 30, 20), changeStatBy[i]);
            statsToChange[i] = (CityData)EditorGUI.EnumPopup(new Rect(40, 25 + i * 25, 95, 20), statsToChange[i]);
        }
        EditorGUILayout.EndScrollView();
    }
}
