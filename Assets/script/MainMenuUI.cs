using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button PlayButton;
    public Button exitButton;
    public Button CreditScene;

    private void Start() 
    {
        PlayButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        CreditScene.onClick.AddListener(CreditGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PinballUtama");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void CreditGame()
    {
        SceneManager.LoadScene("Credit Scene");
    }
}
