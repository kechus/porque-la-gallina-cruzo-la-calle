using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Game,
        FinishLine,
    }

    private static GameController Instance;
    public static GameState CurrentGameState = GameState.MainMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MusicController.PlayMainMenuTheme();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentGameState == GameState.MainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                MusicController.PlayRoster();
                Invoke(nameof(StartGame), 2.5f);
                return;
            }
        }

        var key1 = Input.GetKeyDown(KeyCode.F1);
        var key2 = Input.GetKeyDown(KeyCode.F2);
        var key3 = Input.GetKeyDown(KeyCode.F3);
        var key4 = Input.GetKeyDown(KeyCode.F4);
        var key5 = Input.GetKeyDown(KeyCode.F5);
        var key6 = Input.GetKeyDown(KeyCode.F6);

        if(key1){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 1");
            return;
        }
        if(key2){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 2");
            return;
        }
        if(key2){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 3");
            return;
        }
        if(key3){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 4");
            return;
        }
        if(key4){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 5");
            return;
        }
        if(key5){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 6");
            return;
        }
        if(key6){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
            return;
        }
    }

    private void StartGame()
    {
        CurrentGameState = GameState.Game;
        MusicController.PlayGameTheme();
    }
}
