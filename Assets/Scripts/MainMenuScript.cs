using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject instructionPanel;
    [SerializeField] private GameObject startPanel;


    public void StartGame()
    {
        SceneManager.Instance.StartGame();
    }

    public void Quit()
    {
        Debug.Log("QuitGame");
        SceneManager.Instance.QuitGame();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.Instance.ReturnToMainMenu();
    }

    //Toggle instructionPanel
    public void ToggleInstructionPanel()
    {
        instructionPanel.SetActive(!instructionPanel.activeSelf);
        startPanel.SetActive(!startPanel.activeSelf);
    }
}
