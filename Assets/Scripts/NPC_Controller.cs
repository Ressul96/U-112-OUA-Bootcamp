using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour, Temas
{
    [SerializeField] Diyalog dialog;
    public void Interact()
    {
       StartCoroutine(Diyalog_manager.Instance.diyalog_goster(dialog));
    }
}