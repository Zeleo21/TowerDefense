using TMPro;
using UnityEngine;

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
        playerMoney = 225; // starting money
        playerLives = 3;
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
