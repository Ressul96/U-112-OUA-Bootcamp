using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Dolasma, Diyalog, Saldiri }
public class Game_Controller : MonoBehaviour
{
    [SerializeField] Hareket playercontroller;

    GameState state;

    private void Start()
    {
        Diyalog_manager.Instance.OnShowDialog += () =>
        {
            state = GameState.Diyalog;
        };
        Diyalog_manager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Diyalog)
                state = GameState.Dolasma;
        };
    }

    private void Update()
    {
        if (state == GameState.Dolasma)
        {
            playercontroller.HandleUpdate();
        } 
        else if (state == GameState.Diyalog)
        {
            Diyalog_manager.Instance.HandleUpdate();
        }
        else if (state == GameState.Saldiri)
        {

        }
    }


}
