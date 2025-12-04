using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public void GoToNextLevel(){
        int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", 0);
        Debug.Log("Last level index: " + lastLevelIndex);
        SceneManager.LoadScene(lastLevelIndex + 1);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
