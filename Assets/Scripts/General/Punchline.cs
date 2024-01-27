using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchline : MonoBehaviour
{
    void Update()
    {
        if(GameController.CurrentGameState != GameController.GameState.FinishLine)
        {
            return;
        }
        GetComponent<Animator>().enabled = true;
    }
}
