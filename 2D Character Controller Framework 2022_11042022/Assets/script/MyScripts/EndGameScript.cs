using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("WSOA2023 - 2021 - CCF Base");
    }

    public void QuitGame()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }
}
