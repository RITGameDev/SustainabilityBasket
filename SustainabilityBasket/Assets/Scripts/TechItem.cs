using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Seth Leyens
/// Script that contains functions for the techs in the game
/// </summary>
public class TechItem : MonoBehaviour
{
    #region Public Variables
    public List<TechItem> childTechs;

    public bool startingVisibility;
    public GameObject infoPanel;
    #endregion

    #region Class Variables
    private bool isAvailable;
    private bool isUnlocked;
    #endregion

    #region Properties
    public bool IsAvailable
    {
        get { return IsAvailable; }
        set { IsAvailable = value; }
    }

    public bool IsUnlocked
    {
        get { return isUnlocked; }
        set { isUnlocked = value; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isAvailable = startingVisibility;

        gameObject.SetActive(isAvailable);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAvailable && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }


    /// <summary>
    /// Unlock this tech
    /// </summary>
    public void UnlockTech()
    {
        foreach(TechItem t in childTechs)
        {
            t.isAvailable = true;
            t.gameObject.SetActive(true);
        }

        isUnlocked = true;
        GetComponent<Button>().interactable = false;
    }

    /// <summary>
    /// Used for debug purposes. Draws lines between the techs to show their relationships
    /// </summary>
    private void OnDrawGizmos()
    {
        foreach(TechItem t in childTechs)
        {
            Debug.DrawLine(gameObject.transform.position, t.gameObject.transform.position);
        }
    }
}
