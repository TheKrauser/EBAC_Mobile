using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private CanvasGroup groupStart, groupEnd;

    [SerializeField] private PlayerController player;

    public void StartGame()
    {
        player.ToggleCanRun();
        groupStart.alpha = 0;
        groupStart.interactable = false;
        groupStart.blocksRaycasts = false;
    }

    public void ShowEndScreen()
    {
        player.ToggleCanRun();
        groupEnd.alpha = 1;
        groupEnd.interactable = true;
        groupEnd.blocksRaycasts = true;
    }
}
