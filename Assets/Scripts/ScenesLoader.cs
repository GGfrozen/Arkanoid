using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        int getActiveIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(getActiveIndex + 1);

    }

    public void LoadLastScene()
    {
        int getSceneNumber = SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(getSceneNumber - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public int ReturnIndex()
    {

        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SelectLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
