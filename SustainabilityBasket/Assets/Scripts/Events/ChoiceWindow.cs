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
    public string statChangesAsString;
    public string statChangesToDisplay;

    Vector2 scrollPos;

    List<CityData> cityDataStats;

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

    List<string> cityDataAsString = new List<string>()
    {
        "money",
        "powerRequired",
        "powerSupplied",
        "AQI",
        "costOfLiving",
        "employmentRate",
        "population"
    };

    List<string> cityDataAsFormattedString = new List<string>()
    {
        "Money",
        "Power Required",
        "Power Supplied",
        "AQI",
        "Cost Of Living",
        "Employment Rate",
        "Population"
    };

    public void Init(Rect windowRect)
    {
        this.windowRect = windowRect;
        choiceName = "Input Name Here";
        changeStatBy = new List<float>();
        statsToChange = new List<string>();
        scrollPos = new Vector2();
        cityDataStats = new List<CityData>();
    }

    public void LoadFromFile()
    {
        for (int i = 0; i < statsToChange.Count; i++)
        {
            cityDataStats.Add((CityData)cityDataAsString.IndexOf(statsToChange[i]));
        }
    }

    public void DrawWindow()
    {
        statChangesAsString = "";
        statChangesToDisplay = "";
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
            
            if(statsToChange.Count == 0)
            {
                statChangesAsString = "No stat changes";
                statChangesToDisplay = "No stat changes";
            }
            else
            {
                statChangesAsString = "Stat Changes: \n";
            }

            for (int i = 0; i < statsToChange.Count; i++)
            {
                changeStatBy[i] = EditorGUI.FloatField(new Rect(25, 75 + i * 25, 30, 20), changeStatBy[i]);
                cityDataStats[i] = (CityData)EditorGUI.EnumPopup(new Rect(100, 75 + i * 25, (windowRect.width - 10) - 100, 20), cityDataStats[i]);
                statsToChange[i] = cityDataAsString[(int)cityDataStats[i]];
                statChangesAsString += changeStatBy[i].ToString() + " " + cityDataAsFormattedString[(int)cityDataStats[i]];
                
                if (changeStatBy[i] < 0)
                {
                    statChangesToDisplay += "- " + cityDataAsFormattedString[(int)cityDataStats[i]];
                }
                else if (changeStatBy[i] > 0)
                {
                    statChangesToDisplay += "+ " + cityDataAsFormattedString[(int)cityDataStats[i]];
                }
                else
                {
                    statChangesToDisplay += "= " + cityDataAsFormattedString[(int)cityDataStats[i]];
                }

                if (i + 1 != statsToChange.Count)
                {
                    statChangesAsString += "\n";
                    statChangesToDisplay += "\n";
                }
            }
        }
    }
}
