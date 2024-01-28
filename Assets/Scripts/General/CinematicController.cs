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
        creditsMessages.Enqueue("Global Game Jam 2024\n\n\"Hazme reir\"\n");
        creditsMessages.Enqueue("Programacion:\nDaubeny\nKechus\nOscarMaciasProf");
        creditsMessages.Enqueue("Splash arts:\nCarol");
        creditsMessages.Enqueue("Audio y sonidos:\nMuchas personas");
        creditsMessages.Enqueue("Sprites:\nMuchas personas");
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
        Invoke(nameof(ShowCredits), 6f);
    }

    void CloseGame()
    {
        Application.Quit();
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
        GallinaInstance.GetComponent<Gallina>().enabled = true;
        MusicController.PlayGameTheme();
        hasStarted = true;

        // creditsTextMesh = creditos.GetComponent<TextMeshPro>();
        // messageText = GameObject.Find("Message").GetComponent<TMP_Text>();
        creditos.SetActive(true);
        creditsAnimator = creditos.GetComponent<Animator>();

        var mesh = creditos.GetComponentInChildren<TextMeshProUGUI>();
        var message = creditsMessages.Dequeue();
        mesh.text = message;
        Invoke(nameof(ShowCredits), 3f);
    }

}
