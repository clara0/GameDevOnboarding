using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void RestartGame() {
    	Time.timeScale = 1;
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
