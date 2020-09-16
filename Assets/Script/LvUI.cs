using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvUI : MonoBehaviour
{
   [SerializeField] PlayerParams playerParams;
   [SerializeField] Text SetText;
   
   public void Update()
   {
        SetText.text = " LV : " + playerParams.stat.Lv;
   }
}
