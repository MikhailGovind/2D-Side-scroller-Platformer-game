using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneScript : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("WSOA2023 - 2021 - CCF Base");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
