using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CityData))]
public class CityDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CityData cityData = (CityData)target;


        EditorGUILayout.LabelField("Money", EditorStyles.boldLabel);
        CityData.money = EditorGUILayout.IntField("Money", CityData.money);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("moneyText"));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Power", EditorStyles.boldLabel);
        CityData.powerRequired = EditorGUILayout.IntField("Power Required", CityData.powerRequired);
        CityData.powerSupplied = EditorGUILayout.IntField("Power Supplied", CityData.powerSupplied);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("powerText"));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Air Quality", EditorStyles.boldLabel);
        CityData.AQI = EditorGUILayout.IntField("AQI", CityData.AQI);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AQIColor"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AQIText"));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Conditions", EditorStyles.boldLabel);
        CityData.costOfLiving = EditorGUILayout.FloatField("Cost of Living", CityData.costOfLiving);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("costOfLivingText"));
        CityData.employmentRate = EditorGUILayout.Slider("Employment Rate", CityData.employmentRate, 0, 1.0f);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("employementRateText"));
        CityData.population = EditorGUILayout.IntField("Population", CityData.population);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("populationText"));

        serializedObject.ApplyModifiedProperties();
    }
}
