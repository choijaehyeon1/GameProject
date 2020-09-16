using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(MonsterPreset))]
public class MonsterPresetEditor : PresetEditor { }
#endif

[CreateAssetMenu(fileName = "New MonsterPreset", menuName = "Presets/Monster")]
public class MonsterPreset : Preset
{
    public MonsterStat[] monsters;
}
