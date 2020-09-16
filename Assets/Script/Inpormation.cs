using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inpormation : MonoBehaviour
{
    [SerializeField] Text Settext;
    [SerializeField] PlayerParams playerParams;

    public void Update()
    {
        Settext.text = "     LV : " + playerParams.stat.Lv+"      " + "     Exp : " + playerParams.stat.Exp + "\n" + "     HP : " + playerParams.stat.Hp +
                       "     Attack : " + playerParams.stat.Attack +"\n" +"     Defense : " + playerParams.stat.Defense + "     Gold : " + playerParams.stat.Gold;
    }
}
