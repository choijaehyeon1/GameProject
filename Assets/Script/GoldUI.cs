using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    [SerializeField] PlayerParams playerParams;
    [SerializeField] Text SetText;

    public void Update()
    {
        SetText.text = string.Format("Gold : {0}", playerParams.stat.Gold);
    }
}
