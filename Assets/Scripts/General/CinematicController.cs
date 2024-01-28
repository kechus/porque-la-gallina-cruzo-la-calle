using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CinematicController : MonoBehaviour
{
    public GameObject GallinaPrefab;
    GameObject GallinaInstance;
    Animator animator;
    Animator creditsAnimator;

    [SerializeField]
    GameObject fadeChicken;

    bool hasStarted = false;

    //credits messages
    Queue<string> creditsMessages = new Queue<string>();

    [SerializeField] GameObject creditos;

    void Start()
    {
        GallinaInstance = Instantiate(GallinaPrefab, new Vector3(-7.5f, 0, 0), Quaternion.identity);
        GallinaInstance.GetComponent<Gallina>().enabled = false;
        animator = GallinaInstance.GetComponent<Animator>();
        //populate credits messages
        creditsMessages.Enqueue("Global Game Jam 2024\n\n\"Hazme reír\"\n");
        creditsMessages.Enqueue("Programación: \n Daubeny \n Kechus");
        creditsMessages.Enqueue("Splash art: \n Caribu");
        creditsMessages.Enqueue("Sprites: \n OscarMaciasProf");
        
        creditsMessages.Enqueue("Assets gratis encontrados en:\n itch.io \n opengameart.org \n freesound.org \n");
        creditsMessages.Enqueue("Sprites: \n Cup Nooble \n shubibubi");
        creditsMessages.Enqueue("Sprites:\n vmiinv \n SamueLee \n Umz \n");
        creditsMessages.Enqueue("Audio:\n Owen_Garcia \n Dannaye \n Eponn");
        creditsMessages.Enqueue("Audio:\n PNMCarrieRailfan \n Eponn \n magnuswake");
        creditsMessages.Enqueue("Audio:\n Scpsea \n Tabby+Gus");
        creditsMessages.Enqueue("Audio:\n D4XX \n Preacher13 \n Kevin MacLeod ");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !hasStarted)
        {
            MusicController.PlayRoster();
            Invoke(nameof(StartCinematic), 2.5f);
        }

        if (hasStarted)
        {
            const float MOVE_VELOCITY = 1.5f;
            var RB = GallinaInstance.GetComponent<Rigidbody2D>();
            RB.MovePosition(RB.position + (Time.fixedDeltaTime * MOVE_VELOCITY * new Vector2(1, 0)));
        }
    }

    void StopShowingCredits()
    {
        creditsAnimator.SetTrigger("End");
        var mesh = creditos.GetComponentInChildren<TextMeshProUGUI>();
        var message = creditsMessages.Dequeue();
        mesh.text = message;
        Invoke(nameof(ShowCredits), 4f);
    }

    void CloseGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel 1");
    }

    void ShowCredits()
    {
        if (creditsMessages.Count == 0)
        {
            var fadeAnimator = fadeChicken.GetComponent<Animator>();
            fadeAnimator.SetTrigger("fadeOut");
            fadeAnimator.enabled = true;
            Invoke(nameof(CloseGame), 2f);
            return;
        }
        creditsAnimator.SetTrigger("Start");
        animator.enabled = true;
        Invoke(nameof(StopShowingCredits), 2f);
    }

    void StartCinematic()
    {
        animator.SetBool("Move", true);
        MusicController.PlayGameTheme();
        hasStarted = true;

        creditos.SetActive(true);
        creditsAnimator = creditos.GetComponent<Animator>();

        var mesh = creditos.GetComponentInChildren<TextMeshProUGUI>();
        var message = creditsMessages.Dequeue();
        mesh.text = message;
        Invoke(nameof(ShowCredits), 3f);
    }

}
