using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(SceneManager.GetActiveScene().name == "Nivel 4")
            {
                //GameObject.Find()
            }

            GameController.CurrentGameState = GameController.GameState.FinishLine;
        }
    }
}
