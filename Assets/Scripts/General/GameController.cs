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
            }
        }
    }

    private void StartGame()
    {
        CurrentGameState = GameState.Game;
        MusicController.PlayGameTheme();
    }
}
