using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] MonsterPreset monsterPreset;
    public MonsterPreset Monster => monsterPreset;


    [SerializeField] ItemPreset itemPreset;
    public ItemPreset ItemPreset => itemPreset;


    public Inventory Inventory { get; private set; } = new Inventory();

    public void Save()
    {
        PlayerPrefs.SetString("Inventory", Inventory.ToString());
    }

    public void Load()
    {
        string inventoryStr = PlayerPrefs.GetString("Inventory");
        Inventory.Parse(inventoryStr);
    }
}
