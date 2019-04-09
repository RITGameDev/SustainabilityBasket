using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventMaker : EditorWindow
{
    List<EventEditor> eventWindows = new List<EventEditor>();

    [MenuItem("Window/Event Maker")]
    static void ShowWindow()
    {
        EventMaker window = GetWindow<EventMaker>();
    }

    private void OnGUI()
    {
        //EditorGUILayout.TextField("Event Name:", "")

        //EditorGUILayout.BeginHorizontal();
        BeginWindows();

        for (int i = 0; i < eventWindows.Count; i++)
        {
            eventWindows[i].windowRect = GUI.Window(i, eventWindows[i].windowRect, DrawWindows, eventWindows[i].windowTitle);
        }

        EndWindows();
        //EditorGUILayout.EndHorizontal();

        if (GUI.Button(new Rect(position.width - 100, 0, 100, 15), "Add Event"))
        {
            eventWindows.Add(new EventEditor() { windowRect = new Rect(0, 0, 200, 280) });
        }

        if (GUI.Button(new Rect(position.width - 100, 20, 100, 15), "Delete All"))
        {
            eventWindows.Clear();
        }
    }

    void DrawWindows(int id)
    {
        eventWindows[id].DrawWindow();
        GUI.DragWindow();
    }
}
