using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventEditor : ScriptableObject
{
    Vector2 scrollPos;
    string choiceName;
    List<int> changeStatBy;

    public Rect windowRect;
    public string windowTitle;

    CityData cityData;

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

    public EventEditor()
    {
        choiceName = "Input Name Here";
        windowTitle = choiceName;
        changeStatBy = new List<int>();
    }

    public void DrawWindow()
    {
        choiceName = EditorGUILayout.TextField(choiceName);

        if (GUILayout.Button("Add Stat Change"))
        {
            changeStatBy.Add(0);
        }

        EditorGUI.LabelField(new Rect(10, 65, 30, 25), "Stat Change");
        EditorGUI.LabelField(new Rect(45, 65, 95, 25), "Stat To Change");

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);
        for (int i = 0; i < changeStatBy.Count; i++)
        {
            changeStatBy[i] = EditorGUI.IntField(new Rect(5, 25 + i * 25, 30, 20), changeStatBy[i]);
        }
        EditorGUILayout.EndScrollView();
    }
}
