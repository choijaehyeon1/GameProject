using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderDialog : MonoBehaviour
{
    public string sceneName;
    public string dialogContent;    
    
    public void ShowDialog()
    {
        DialogUI.Show(dialogContent,
                "네", () => { YesButton(); },
                "아니오", () => { }
                );
    }

    public void YesButton()
    {
        LoadingManager.LoadScene("Tower");
    }
    
}
