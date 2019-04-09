using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityData : MonoBehaviour
{
    [Header("Money")]
    public int money;
    [SerializeField] private TextMeshProUGUI moneyText;

    [Space(5)]
    [Header("Power")]
    public int powerRequired;
    public int powerSupplied;
    [SerializeField] private TextMeshProUGUI powerText;

    [Space(5)]
    [Header("Air Quality")]
    public int AQI; //Air Quality Index
    private const int maxAQI = 500;
    [SerializeField] private Gradient AQIColor;
    [SerializeField] private TextMeshProUGUI AQIText;

    [Space(5)]
    [Header("Conditions")]
    public float costOfLiving;
    [SerializeField] private TextMeshProUGUI costOfLivingText;

    [Range(0,1)]public float employmentRate;
    [SerializeField] private TextMeshProUGUI employementRateText;

    public int population;
    [SerializeField] private TextMeshProUGUI populationText;


    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        moneyText.text = (money > 0 ? "Money: $" : "Money: -$") + Mathf.Abs(money);
        powerText.text = "Power: " + powerSupplied + "/" + powerRequired;

        AQIText.text = "AQI: " + AQI;
        AQIText.color = AQIColor.Evaluate(AQI / (float)maxAQI);

        costOfLivingText.text = "Cost of life: " + costOfLiving;
        employementRateText.text = "Employment: " + (employmentRate * 100) + "%";
        populationText.text = "Population: " + population;
    }
}
