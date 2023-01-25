using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CompleteLevelUI;

    bool Gamehasended = false;

    public float restartdelay = 1f; 

    public void CompleteLevel()
    {
       CompleteLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (Gamehasended == false)
        {
            Gamehasended = true;

            Debug.Log("Game Over");

            Invoke("Restart", restartdelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
