using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int startMoney = 100;
    public static int curMoney;
    [SerializeField] private int startHealth = 100;
    [SerializeField] private int curHealth = 100;
    [SerializeField] private Text healthText;
    [SerializeField] private Text moneyText;

    private void Start()
    {
        curMoney = startMoney;
        curHealth = startHealth;
    }
    private void Update()
    {
        healthText.text = "Health: " + curHealth.ToString();
        moneyText.text = "Money: $" + curMoney.ToString();
    }
    public void TakeDamage(int dmg) 
    {
        curHealth -= dmg;
        if (curHealth <= 0) 
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!!");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
