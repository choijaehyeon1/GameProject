using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    public GameObject InvenPanel;
    public GameObject SkillPanel;
    public GameObject EqipPanel;
    public GameObject EncyPanel;
    bool activeMenu = false;

    private void Start()
    {
        InvenPanel.SetActive(activeMenu);
        SkillPanel.SetActive(activeMenu);
        EqipPanel.SetActive(activeMenu);
        EncyPanel.SetActive(activeMenu);
    }

    public void ToggleMeuePanel()
    {
        activeMenu = !activeMenu;
        InvenPanel.SetActive(activeMenu);
        SkillPanel.SetActive(activeMenu);
        EqipPanel.SetActive(activeMenu);
        EncyPanel.SetActive(activeMenu);
    }
}
