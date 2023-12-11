#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UpgradeHandler))]
public class UpgradeHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UpgradeHandler upgradeHandler = (UpgradeHandler)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Add xp"))
        {
            upgradeHandler.AddXp(10);
        }
    }
}

#endif