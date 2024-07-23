using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Diyalog_manager : MonoBehaviour
{
    [SerializeField] GameObject diyalog_penceresi;
    [SerializeField] Text diyalog_yazisi;
    [SerializeField] int lettersPerSecond;
    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static Diyalog_manager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    Diyalog dialog;
    int currentline = 0;
    bool isTyping;


    public IEnumerator diyalog_goster(Diyalog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        diyalog_penceresi.SetActive(true);
        StartCoroutine(Diyalogyaz(dialog.Lines[0]));

    }
    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Z) && !isTyping)
        {
            ++currentline;
            if (currentline < dialog.Lines.Count)
            {
                StartCoroutine(Diyalogyaz(dialog.Lines[currentline]));
            }
            else
            {
                diyalog_penceresi.SetActive(false);
                currentline = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator Diyalogyaz(string line)
    {
        isTyping = true;
        diyalog_yazisi.text = "";
        foreach (var letter in line.ToCharArray())
        {
            diyalog_yazisi.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
