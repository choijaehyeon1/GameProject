using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LookAtTrigger : MonoBehaviour
{
    public UnityEvent OnEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           Vector3 delta = other.transform.position - transform.position;
           delta.y = 0.0f;
           transform.rotation = Quaternion.LookRotation(delta);
           
           OnEnter?.Invoke();
        }
    }
}
