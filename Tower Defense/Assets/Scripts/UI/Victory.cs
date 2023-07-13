using UnityEngine.SceneManagement;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Main Menu");
    }
}
