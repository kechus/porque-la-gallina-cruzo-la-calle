using System;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(GameController.CurrentGameState == GameController.GameState.Game)
        {
            return;
        }
        
        if (GameController.CurrentGameState == GameController.GameState.FinishLine && Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("fadeOut");
            animator.enabled = true;
            Invoke(nameof(LoadScene), 2f);
            return;
        }
    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 2");
    }
}
