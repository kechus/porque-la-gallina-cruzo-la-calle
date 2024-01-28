using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ShowEndTransition();
    }

    void ShowEndTransition()
    {
        var animator = GameObject.Find("FadeTransition").GetComponentInChildren<Animator>();
        animator.SetTrigger("fadeOut");
        animator.enabled = true;
        Invoke(nameof(Close), 2f);
    }

    void Close()
    {
        Debug.Log("Closed game");
        Application.Quit();
    }
}

