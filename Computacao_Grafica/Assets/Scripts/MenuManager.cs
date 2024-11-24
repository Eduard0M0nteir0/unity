using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    public void Play()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Exit()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
