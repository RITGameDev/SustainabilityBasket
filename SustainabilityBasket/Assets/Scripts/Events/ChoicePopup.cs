using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoicePopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI choiceName;
    [SerializeField]
    private TextMeshProUGUI statChanges;

    private MajorEventChoices currentChoice;

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

    public void CreatePopup(MajorEventChoices currentChoice)
    {
        this.currentChoice = currentChoice;
        choiceName.text = currentChoice.choiceName;
        statChanges.text = currentChoice.statChangesToDisplay;
    }

    public void ApplyChanges()
    {
        for (int i = 0; i < currentChoice.statChanges.Count; i++)
        {
            switch (currentChoice.statsToChange[i])
            {
                case "money":
                    CityData.money += (int)currentChoice.statChanges[i];
                    break;
                case "powerRequired":
                    CityData.powerRequired += (int)currentChoice.statChanges[i];
                    break;
                case "powerSupplied":
                    CityData.powerSupplied += (int)currentChoice.statChanges[i];
                    break;
                case "AQI":
                    CityData.AQI += (int)currentChoice.statChanges[i];
                    break;
                case "costOfLiving":
                    CityData.costOfLiving += currentChoice.statChanges[i];
                    break;
                case "employmentRate":
                    CityData.employmentRate += currentChoice.statChanges[i];
                    break;
                case "population":
                    CityData.population += (int)currentChoice.statChanges[i];
                    break;
            }
        }
    }
}
