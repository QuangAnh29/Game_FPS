using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int PlayerHP = 100;
    public static bool isGameOver;

    public TextMeshProUGUI PlayerHPText;


    private void Start()
    {
        PlayerHP = 100;
        isGameOver = false;
    }

    private void Update()
    {
        PlayerHPText.text = "" + PlayerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("Level");
        }
    }

    public static void TakeDamage(int damageAmount)
    {
        PlayerHP -= damageAmount;
        if(PlayerHP <= 0)
        {
            isGameOver = true;
        }
    }
}
