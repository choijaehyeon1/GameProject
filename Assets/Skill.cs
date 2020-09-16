using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] PlayerParams playerParams;
    [SerializeField] Text SkillPoint;
    [SerializeField] Text Skill1;
    [SerializeField] Text Skill2;
    [SerializeField] Text Skill3;
    [SerializeField] Text Skill4;


    public void Update()
    {
        SkillPoint.text = " SkillPoint : " + playerParams.stat.SkillPoint;

        Skill1.text = "송곳뚫기 Lv : " + playerParams.stat.Skill1Lv + "\n적에게 자기 공격력의 150% 만큼 데미지를 줍니다.\n쿨타임 : 5초";
    }

    public void SkillPointButton()
    {
        if (playerParams.stat.SkillPoint > 0)
        {
            playerParams.stat.Skill1Lv++;
            playerParams.stat.SkillPoint--;
        }
        
    }
}
