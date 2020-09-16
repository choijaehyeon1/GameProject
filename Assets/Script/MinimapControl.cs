using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinimapControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        var minimapPositionObject = GameObject.FindGameObjectWithTag("Minimap");
        if (!minimapPositionObject)
            return;

        transform.position = minimapPositionObject.transform.position;
        transform.rotation = minimapPositionObject.transform.rotation;
    }
}
