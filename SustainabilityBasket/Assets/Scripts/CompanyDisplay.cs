using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        UpdateCompanyName();
    }

     GetText(GameObject go)
    {
        return go.GetComponent<TextMesh>();
    }

    void UpdateCompanyName()
    {
        GetText(GameObject.Find("CompanyDisplay/CompanyName")).text = corp.name;
    }
}
