using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerStat
{//플레이어 파라미터
    public int Lv;
    public int Gold;
    public int maxLv;
    public float Exp;
    public float maxExp;
    public float Hp;
    public float maxHp;
    public float Attack;
    public float Defense;
 //플레이어 스킬 파라미터
    public int SkillPoint;
    public int Skill1Lv;
    public int Skill2Lv;
    public int Skill3Lv;
    public int Skill4Lv;
//플레이어 레벨업 파라미터
    public int[] Lvup;
    public int[] Hpup;
    public int[] Attackup;
    public int[] Defenseup;
}


public class PlayerParams : MonoBehaviour
{
   public PlayerStat stat = new PlayerStat();

    public void Start()
    {
        stat.Lv = 1;
        stat.Gold = 0;
        stat.maxLv = 99;
        stat.SkillPoint = 0;
        stat.Skill1Lv = 0;
        stat.Skill2Lv = 0;
        stat.Skill3Lv = 0;
        stat.Skill4Lv = 0;
        stat.Hp = stat.Hpup[1];
        stat.maxHp = stat.Hpup[1];
        stat.maxExp = stat.Lvup[1];
        stat.Attack = stat.Attackup[1];
        stat.Defense = stat.Defenseup[1];     
    }

    public void Update()
    {
        LevelUp();
    }
    public void StatUp()
    {
        stat.Lv++;
        stat.SkillPoint++;
        stat.maxExp = stat.Lvup[stat.Lv];
        stat.Hp = stat.Hpup[stat.Lv];
        stat.maxHp = stat.Hpup[stat.Lv];
        stat.Attack = stat.Attackup[stat.Lv];
        stat.Defense = stat.Defenseup[stat.Lv];
        stat.Exp = 0;
    }
    
    public void LevelUp()
    {
        if(stat.maxLv > stat.Lv)
        {
            if (stat.Exp >= stat.Lvup[stat.Lv])
            {
                StatUp();
            }
            else
            {

            }
        }
        else
        {
            stat.Exp = 0;
        }
    }
}
