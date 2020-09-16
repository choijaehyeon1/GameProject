using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActive : MonoBehaviour
{
    public GameObject EquipPenel;
    public GameObject InvenPenel;
    public GameObject SkillPenel;
    bool actSkill = false;
    bool activeEquip = false;
    bool actinven = false;

    private void Start()
    {
        EquipPenel.SetActive(activeEquip);
        InvenPenel.SetActive(actinven);
        SkillPenel.SetActive(actSkill);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activeEquip = !activeEquip;
            EquipPenel.SetActive(activeEquip);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            actSkill = !actSkill;
            SkillPenel.SetActive(actSkill);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            actinven = !actinven;
            InvenPenel.SetActive(actinven);
        }
    }
    public void EquipPanel()
    {
        activeEquip = !activeEquip;
        EquipPenel.SetActive(activeEquip);
    }
    public void InvenPanel()
    {
        actinven = !actinven;
        InvenPenel.SetActive(actinven);
    }
    public void SkillPanel()
    {
        actSkill = !actSkill;
        SkillPenel.SetActive(actSkill);
    }
}
