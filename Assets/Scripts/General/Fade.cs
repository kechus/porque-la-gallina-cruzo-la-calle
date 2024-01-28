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
        GameController.CurrentGameState = GameController.GameState.MainMenu;
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 1"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 2");
            return;
        }
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 2"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 3");
            return;
        }
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 3"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 4");
            return;
        }
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 4"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 5");
            return;
        }
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 5"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 6");
            return;
        }
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Nivel 6"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
            return;
        }
    }
}
