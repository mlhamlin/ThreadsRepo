using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TeleportZone))]
public class TeleportZoneEditor: Editor
{
    string[] DestNames;

    public override void OnInspectorGUI()
    {
        TeleportZone Zone = target as TeleportZone;

        int choice = Zone.getSelectedIndex();
        // Draw the default inspector
        DrawDefaultInspector();

        if (Zone.Destination != null)
        {
            DestNames = new string[Zone.Destination.entryPoints.Count];
            for(int i = 0; i < Zone.Destination.entryPoints.Count; i++)
            {
                DestNames[i] = Zone.Destination.entryPoints[i].gameObject.name;
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Transform");
            choice = EditorGUILayout.Popup(choice, DestNames);
            EditorGUILayout.EndHorizontal();

            Zone.setEntryLocation(choice, Zone.Destination.entryPoints[choice]);
        }

        EditorUtility.SetDirty(target);
    }
}
