using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChoiceWindow : ScriptableObject
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
    }
}
