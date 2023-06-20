using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;

    public GameObject gameOverUI;
    
    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.instance.playerLives <= 0 || Input.GetKeyDown("c"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
