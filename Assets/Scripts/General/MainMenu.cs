using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    bool Started = false;

    void Update()
    {
        if (!Started)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GetComponent<Animator>().SetTrigger("started");
            }
        }
    }
}