using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Seth Leyens
/// Script that handles what happens at the end of a round
/// </summary>
public class RoundManager : MonoBehaviour
{
    #region Public Variables
    public Timeline timeline;
    #endregion

    #region Class Variables
    private int netMoney;
    private int netPowerLimit;
    private int netPop;
    private int netAQI;
    private TechItem selectedTech;
    #endregion

    #region Properties
    public int NetMoney
    {
        get { return netMoney; }
    }

    public int NetPop
    {
        get { return netPop; }
    }

    public int NetPowerLimit
    {
        get { return netPowerLimit; }
    }

    public int NetAQI
    {
        get { return netAQI; }
    }

    public TechItem SelectedTech
    {
        get { return selectedTech; }
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        netMoney = 0;
        netPowerLimit = 0;
        netPop = 0;
        netAQI = 0;
        selectedTech = null;
    }

    /// <summary>
    /// Reset all the values we keep track of for the round
    /// </summary>
    private void ResetRound()
    {
        netMoney = 0;
        netPowerLimit = 0;
        netPop = 0;
        netAQI = 0;
        selectedTech = null;
    }

    /// <summary>
    /// Update the amount of money the player will recieve at the end of the round
    /// </summary>
    /// <param name="valueChange">The change in money. Use negative values for losing money, positive values for gaining money</param>
    public void ModifyMoney(int valueChange)
    {
        netMoney += valueChange;
    }

    /// <summary>
    /// Update the amount the power requirements will change in the next round
    /// </summary>
    /// <param name="valueChange">The change in power. Use negative values for losing power, positive values for gaining power</param>
    public void ModifyPower(int valueChange)
    {
        netPowerLimit += valueChange;
    }

    /// <summary>
    /// Update the amount the population will change in the next round
    /// </summary>
    /// <param name="valueChange">The change in population. Use negative values for losing population, positive values for gaining population</param>
    public void ModifyPopulation(int valueChange)
    {
        netPop += valueChange;
    }

    /// <summary>
    /// Update the amount the AQI will change in the next round
    /// </summary>
    /// <param name="valueChange">The change in AQI. Use negative values for decreasing AQI, positive values for increasing AQI</param>
    public void ModifyAQI(int valueChange)
    {
        netAQI += valueChange;
    }

    /// <summary>
    /// Select which tech will be unlocked at the end of the round
    /// </summary>
    /// <param name="tech">The tech to select</param>
    public void SelectTech(TechItem tech)
    {
        //Make sure this is a valid selection
        if(!tech.IsUnlocked && tech.IsAvailable)
        {
            selectedTech = tech;
        }
    }

    /// <summary>
    /// Go to the next round
    /// </summary>
    public void NextRound()
    {
        if(selectedTech == null)
        {
            //TODO: This is temporary, we should probably display some sort of warning for the player
            return;
        }
        else
        {
            selectedTech.UnlockTech();

            //Set the relevant city data values
            CityData.money += netMoney;
            CityData.population += netPop;
            CityData.powerRequired += netPowerLimit;
            CityData.AQI += netAQI;

            //Reset the round and move the timeline
            ResetRound();
            timeline.TriggerTimeline();
        }
    }

}
