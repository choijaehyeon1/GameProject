using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[UnityEditor.CustomEditor(typeof(ItemPreset))]
public class ItemPresetEditor : PresetEditor 
{
    //public override void OnInspectorGUI()
    //{
    //    DrawExportButton();
    //    DrawImportButton();

    //    serializedObject.Update();

    //    var data = serializedObject.FindProperty("data");
    //    data.isExpanded = EditorGUILayout.Foldout(data.isExpanded, data.displayName);
    //    if (data.isExpanded)
    //    {
    //        EditorGUI.indentLevel++;
    //        data.arraySize = EditorGUILayout.IntField("Size", data.arraySize);

    //        for (int dataIndex = 0; dataIndex < data.arraySize; dataIndex++)
    //        {
    //            var item = data.GetArrayElementAtIndex(dataIndex);
    //            EditorGUI.BeginChangeCheck();
    //            EditorGUILayout.PropertyField(item);
    //            if (EditorGUI.EndChangeCheck())
    //            {
    //                var icon = item.FindPropertyRelative("Icon").objectReferenceValue;
    //                var iconPath = item.FindPropertyRelative("IconPath");
    //                iconPath.stringValue = AssetDatabase.GetAssetPath(icon);
    //            }
    //        }
    //        EditorGUI.indentLevel--;
    //    }
    //    serializedObject.ApplyModifiedProperties();
    //}

    protected override void ImportJson()
    {
        base.ImportJson();

        var data = (target as ItemPreset).data;

        for (int i = 0; i < data.Length; i++)
        {
            data[i].Icon = AssetDatabase.LoadAssetAtPath(data[i].IconPath, typeof(Sprite)) as Sprite;
        }
    }

    protected override void ExportJson()
    {
        var data = (target as ItemPreset).data;

        for (int i = 0; i < data.Length; i++)
        {
            data[i].IconPath = AssetDatabase.GetAssetPath(data[i].Icon);
        }

        base.ExportJson();
    }
}



#endif

[Serializable]
public struct ItemData
{
    public string Kinds;
    public int ID;
    public string Name;
    public float Atk;
    public float Def;
    public float Health;
    public int Buy;
    public int Sell;
    public Sprite Icon;
    public string IconPath;
}

[CreateAssetMenu(fileName = "New ItemPreset", menuName = "Presets/Item")]
public class ItemPreset : Preset
{
    public ItemData[] data;
}
