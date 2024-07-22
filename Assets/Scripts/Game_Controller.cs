using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Dolasma, Diyalog, Saldiri }
public class Game_Controller : MonoBehaviour
{
    [SerializeField] Hareket playercontroller;

    GameState state;

    private void Update()
    {
        if (state == GameState.Dolasma)
        {
            playercontroller.HandleUpdate();
        } 
        else if (state == GameState.Diyalog)
        {

        }
        else if (state == GameState.Saldiri)
        {

        }
    }


}
