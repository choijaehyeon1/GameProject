using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] PlayerParams playerParams;
    [SerializeField] Image slExp;
    [SerializeField] Text SetText;

    public void Update()
    {
        slExp.fillAmount = (float)playerParams.stat.Exp / playerParams.stat.maxExp;
        SetText.text = string.Format("EXP : {0} / {1}", playerParams.stat.Exp, playerParams.stat.maxExp);
    }
}
