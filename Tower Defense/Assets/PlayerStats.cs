using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats instance;
    
    public int playerMoney;

    public int playerLives;

    public TMP_Text playerLivesText;

    public int roundsSurvived;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Already a PlayerStats in the Scene");
            return;
        }
        instance = this;
    }
    
    void Start()
    {
        playerMoney = 150; // starting money
        playerLives = 1;
        playerLivesText.text = playerLives.ToString();
        roundsSurvived = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseHealth()
    {
        playerLives -= 1;
        playerLivesText.text = playerLives.ToString();
    }
    
}
