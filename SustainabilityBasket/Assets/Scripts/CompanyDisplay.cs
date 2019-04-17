using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class CompanyDisplay : MonoBehaviour
{
    [SerializeField]
    Corporation corp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProp("CompanyName", corp.name);
        UpdateProp("PowerSupplied", corp.power.ToString());
        UpdateProp("AQIContributed", corp.aqi.ToString());
        UpdateProp("Cost", corp.cost.ToString());
    }

    TextMeshProUGUI GetText(GameObject go)
    {
        return go.GetComponent<TextMeshProUGUI>();
    }

    //void UpdateCompanyName()
    //{
    //    GetText(GameObject.Find("CompanyDisplay/CompanyName")).text = corp.name;
    //}
    void UpdateProp(string prop, string value)
    {
        GetText(GameObject.Find("CompanyDisplay/" + prop)).text = value;
    }
}
