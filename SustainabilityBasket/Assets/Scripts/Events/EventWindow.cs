using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventWindow : ScriptableObject
{
    Vector2 scrollPos;

    public string windowTitle;
    public Rect windowRect;
    public List<ChoiceWindow> choices;

    string eventName;
    string eventDescription;

    public string Description
    {
        get { return eventDescription; }
        set { eventDescription = value; }
    }

    public string EventName
    {
        get { return eventName; }
        set { eventName = value; }
    }

    public bool ChoiceAdded
    {
        get;
        set;
    }

    public bool AllRemoved
    {
        get;
        set;
    }

    public EventWindow()
    {
        eventName = "New Event";
        windowTitle = eventName;
        eventDescription = "Description";
        choices = new List<ChoiceWindow>();
    }

    public void DrawWindow()
    {
        windowTitle = eventName = EditorGUILayout.TextField(eventName);
        eventDescription = EditorGUILayout.TextArea(eventDescription, GUILayout.Height(100));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Choice"))
        {
            ChoiceWindow temp = CreateInstance<ChoiceWindow>();
            temp.Init(new Rect(6, 160, 252, 280));
            choices.Add(temp);
            ChoiceAdded = true;
        }

        if (GUILayout.Button("Remove All"))
        {
            choices.Clear();
            AllRemoved = true;
        }
        GUILayout.EndHorizontal();

        using (GUILayout.HorizontalScope scope = new GUILayout.HorizontalScope())
        {
            for (int i = 0; i < choices.Count; i++)
            {
                if (i > 0)
                {
                    choices[i].windowRect.x = choices[i - 1].windowRect.x + choices[i - 1].windowRect.width + 5;
                }
                choices[i].DrawWindow();
            }
        }
    }
}
