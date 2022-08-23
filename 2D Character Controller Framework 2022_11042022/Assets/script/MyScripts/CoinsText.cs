using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsText : MonoBehaviour
{
    public LevelManager levelManager;
    public TextMeshProUGUI coinsText;

    private void Update()
    {
        coinsText.text = "Coins: " + levelManager.score;
    }
}
