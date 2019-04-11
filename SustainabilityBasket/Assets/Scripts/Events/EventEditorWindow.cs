using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventEditorWindow : EditorWindow
{
    List<EventWindow> eventWindows = new List<EventWindow>();
    EventWindow currentWindow;

    int SelectedEvent
    {
        get { return EditorPrefs.GetInt("SelectedEvent", 0); }
        set { EditorPrefs.SetInt("SelectedEvent", value); }
    }

    static MajorEventDetails eventList;

    [MenuItem("Window/Event Maker")]
    public static void ShowWindow()
    {
        EventEditorWindow window = GetWindow<EventEditorWindow>("Event Editor");
        window.minSize = new Vector2(770, 500);
        eventList = AssetDatabase.LoadAssetAtPath<MajorEventDetails>("Assets/Scripts/Events/MajorEvents.asset");
    }

    private void OnGUI()
    {
        if (!eventList)
        {
            eventList = AssetDatabase.LoadAssetAtPath<MajorEventDetails>("Assets/Scripts/Events/MajorEvents.asset");
        }

        if (eventWindows.Count == 0)
        {
            currentWindow = null;
        }

        EventSidebar(position);

        if (currentWindow != null)
        {
            DrawEditorWindow();
        }
    }

    void DrawEditorWindow()
    {
        BeginWindows();

        currentWindow.windowRect = GUILayout.Window(SelectedEvent, currentWindow.windowRect, DrawWindows, currentWindow.windowTitle);

        EndWindows();
    }

    void DrawWindows(int id)
    {
        eventWindows[id].DrawWindow();
    }

    void EventSidebar(Rect windowRect)
    {
        Vector2 scrollPos = new Vector2();

        Handles.BeginGUI();
        
        GUILayout.BeginArea(new Rect(0, 0, 240, windowRect.height), GUIContent.none, EditorStyles.textArea);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Event"))
        {
            EventWindow temp = CreateInstance<EventWindow>();
            temp.windowRect = new Rect(250, 0, position.width - 250, position.height);
            eventWindows.Add(temp);
            eventList.majorEvents.Add(new MajorEvents()
            {
                eventName = eventWindows[eventWindows.Count - 1].EventName,
                eventDescription = eventWindows[eventWindows.Count - 1].Description,
                choices = new List<MajorEventChoices>()
            });
        }

        if (GUILayout.Button("Delete All"))
        {
            eventWindows.Clear();
            eventList.majorEvents.Clear();
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();
        if (eventList.majorEvents.Count != 0)
        {
            for (int i = 0; i < eventList.majorEvents.Count; i++)
            {
                EventSidebar(i, windowRect);
            }
        }
        GUILayout.EndVertical();

        GUILayout.EndArea();

        Handles.EndGUI();
    }

    private void EventSidebar(int index, Rect windowRect)
    {
        bool isActive = false;

        if (index == SelectedEvent)
        {
            isActive = true;

            currentWindow = eventWindows[index];

            if (currentWindow.ChoiceAdded)
            {
                eventList.majorEvents[index].choices.Add(new MajorEventChoices()
                {
                    choiceName = "Input Name Here",
                    statChanges = new List<float>(),
                    statsToChange = new List<string>()
                });
                currentWindow.ChoiceAdded = false;
            }

            eventList.majorEvents[index].eventName = currentWindow.EventName;
            eventList.majorEvents[index].eventDescription = currentWindow.Description;

            for (int i = 0; i < currentWindow.choices.Count; i++)
            {
                eventList.majorEvents[index].choices[i].choiceName = currentWindow.choices[i].choiceName;
                eventList.majorEvents[index].choices[i].statChanges = currentWindow.choices[i].changeStatBy;
                eventList.majorEvents[index].choices[i].statsToChange = currentWindow.choices[i].statsToChange;
            }
        }

        if (eventList.majorEvents[index].choices.Count != 0)
        {
            eventList.majorEvents[index].showChoices = EditorGUILayout.Foldout(eventList.majorEvents[index].showChoices, eventList.majorEvents[index].eventName, true);
        }
        else
        {
            EditorGUILayout.SelectableLabel(eventList.majorEvents[index].eventName, GUILayout.Height(15));
        }

        if (eventList.majorEvents[index].showChoices)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginVertical();
            for (int i = 0; i < eventList.majorEvents[index].choices.Count; i++)
            {
                GUILayout.Label(eventList.majorEvents[index].choices[i].choiceName);
            }
            GUILayout.EndVertical();

            EditorGUI.indentLevel--;
        }
    }
}
