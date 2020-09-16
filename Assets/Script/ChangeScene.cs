using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public void OnClickButtonPlay()
    {
        //GameManager.Instance.User.SetPlayerUIAlpha(1.0f);
        SceneManager.LoadScene("Town");
    }
}
