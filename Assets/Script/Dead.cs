using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    public void dead()
    {
        SceneManager.LoadScene("Town");
    }
}
