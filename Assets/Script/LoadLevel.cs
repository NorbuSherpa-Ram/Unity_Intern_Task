using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
      public void LoadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
