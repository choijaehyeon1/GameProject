#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class PresetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawExportButton();
        DrawImportButton();

        base.OnInspectorGUI();
    }

    protected bool DrawExportButton()
    {
        if (GUILayout.Button("내보내기"))
        {
            ExportJson();
            return true;
        }
        return false;
    }

    protected virtual void ExportJson()
    {
        string json = JsonUtility.ToJson(target);
        string path = EditorUtility.SaveFilePanel(target.GetType().Name + "JSON 저장하기",
            Application.dataPath,
            target.GetType().Name,
            "json");
        File.WriteAllText(path, json);
        AssetDatabase.Refresh();
    }

    protected bool DrawImportButton()
    {
        if (GUILayout.Button("가져오기"))
        {
            ImportJson();
            return true;
        }
        return false;
    }

    protected virtual void ImportJson()
    {
        string path = EditorUtility.OpenFilePanel(target.GetType().Name + "JSON 불러오기",
                Application.dataPath, "json");
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, target);
    }
}
#endif