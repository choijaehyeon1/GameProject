using UnityEngine;
using System;

public interface IJsonImportable
{
    bool Success();
}

[Serializable]
public class MonstersInfo : IJsonImportable
{
    public MonsterStat[] monsters;

    public bool Success()
    {
        return monsters != null && monsters.Length > 0;
    }
}
[Serializable]
public struct MonsterStat 
{
    public int ID;
    public string Name;
    public float Hp;
    public float Atk;
    public float Def;
    public float Exp;
    public float Gold;
    public string PrefabName;
}
