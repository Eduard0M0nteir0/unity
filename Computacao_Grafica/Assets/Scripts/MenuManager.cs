using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject initialMenuPanel;
    [SerializeField] private GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadScene(levelName);
    }

    public void OpenAbout()
    {
        initialMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ExitAbout()
    {
        initialMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
