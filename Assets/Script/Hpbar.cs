using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField]PlayerParams playerParams;
    [SerializeField] Image slHp;
    [SerializeField] Text SetText;

    public void Update()
    {
        slHp.fillAmount = (float)playerParams.stat.Hp / playerParams.stat.maxHp;
        SetText.text = string.Format("HP : {0} / {1}", playerParams.stat.Hp, playerParams.stat.maxHp);
    }
}
