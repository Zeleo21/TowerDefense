using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }

        if (PlayerStats.instance.playerLives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }
}
