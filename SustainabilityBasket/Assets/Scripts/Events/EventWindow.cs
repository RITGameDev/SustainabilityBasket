using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// TODO: Make Windows inside Windows
public class EventWindow : ScriptableObject
{
    Vector2 scrollPos;

    public string windowTitle;
    public Rect windowRect;
    public List<ChoiceEditor> choices;

    string eventName;
    string eventDescription;

    public string Description
    {
        get { return eventDescription; }
    }

    public string EventName
    {
        get { return eventName; }
    }

    public bool ChoiceAdded
    {
        get;
        set;
    }

    public EventWindow()
    {
        eventName = "New Event";
        windowTitle = eventName;
        eventDescription = "Description";
        choices = new List<ChoiceEditor>();
    }

    public void DrawWindow()
    {
        eventName = EditorGUILayout.TextField(eventName);
        eventDescription = EditorGUILayout.TextArea(eventDescription, GUILayout.Height(100));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Choice"))
        {
            ChoiceEditor temp = CreateInstance<ChoiceEditor>();
            temp.Init(new Rect(6, 160, 252, 280));
            choices.Add(temp);
            ChoiceAdded = true;
        }

        if (GUILayout.Button("Remove All"))
        {
            choices.Clear();
        }
        GUILayout.EndHorizontal();

        using (GUILayout.HorizontalScope scope = new GUILayout.HorizontalScope())
        {
            for (int i = 0; i < choices.Count; i++)
            {
                if (i > 0)
                {
                    choices[i].windowRect.x = choices[i - 1].windowRect.x + choices[i - 1].windowRect.width + 5;
                }
                choices[i].DrawWindow();
            }
        }
    }
}

public class ChoiceEditor : ScriptableObject
{
    public Rect windowRect;
    public string choiceName;
    public List<float> changeStatBy;
    public List<string> statsToChange;

    List<CityData> cityDataStats;

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

    public void Init(Rect windowRect)
    {
        this.windowRect = windowRect;
        choiceName = "Input Name Here";
        changeStatBy = new List<float>();
        cityDataStats = new List<CityData>();
        statsToChange = new List<string>();
        scrollPos = new Vector2();
    }

    public void DrawWindow()
    {
        GUIStyle style = new GUIStyle();
        using (GUILayout.AreaScope scope = new GUILayout.AreaScope(windowRect, choiceName, GUI.skin.window))
        {
            //GUILayout.BeginArea(windowRect, choiceName);

            choiceName = EditorGUILayout.TextField(choiceName);

            if (GUILayout.Button("Add Stat Change"))
            {
                changeStatBy.Add(0);
                cityDataStats.Add(CityData.money);
                statsToChange.Add("money");
            }

            GUILayout.BeginHorizontal();
            GUILayout.Label("Stat Change");
            GUILayout.Label("Stat To Change");
            GUILayout.EndHorizontal();

            //scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);
            for (int i = 0; i < changeStatBy.Count; i++)
            {
                changeStatBy[i] = EditorGUI.FloatField(new Rect(25, 75 + i * 25, 30, 20), changeStatBy[i]);
                cityDataStats[i] = (CityData)EditorGUI.EnumPopup(new Rect(100, 75 + i * 25, (windowRect.width - 10) - 100, 20), cityDataStats[i]);
                statsToChange[i] = cityDataStats[i].ToString();
            }
            //EditorGUILayout.EndScrollView();
        }
        //GUILayout.EndArea();
    }
}
