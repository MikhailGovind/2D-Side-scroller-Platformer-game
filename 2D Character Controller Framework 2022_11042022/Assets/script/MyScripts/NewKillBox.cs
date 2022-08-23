using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewKillBox : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (player)
        {
            SceneManager.LoadScene("WSOA2023 - 2021 - CCF Base");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
