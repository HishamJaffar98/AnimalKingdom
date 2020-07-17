using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    #region Fields
    static int buildIndex = SceneManager.GetActiveScene().buildIndex;
    static float timeToLoadScene = 1f;
    #endregion

    #region Properties
    public static int BuildIndex
    {
        get
        {
            return buildIndex;
        }
    }

    public static float TimeToLoadScene
    {
        get
        {
            return timeToLoadScene;
        }
    }
    #endregion

    #region Methods
    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(buildIndex + 1);
        IncrementBuildIndex();
    }

    public static void LoadPrevLevel()
    {
        SceneManager.LoadScene(buildIndex - 1);
        DecrementBuildIndex();
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }

    static void IncrementBuildIndex()
    {
        buildIndex += 1;
    }

    static void DecrementBuildIndex()
    {
        buildIndex -= 1;
    }
    #endregion
}
