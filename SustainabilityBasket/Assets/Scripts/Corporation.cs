using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Corporation", menuName = "Corporation", order = 1)]
public class Corporation : ScriptableObject
{
    public new string name;
    public int power;
    public int aqi;
    public int cost;
}
