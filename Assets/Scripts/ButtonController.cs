using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    ShowDetails showDetails;
    public void Start()
    {
        showDetails = FindObjectOfType<ShowDetails>();
    }
    public void PlayButtonClicked()
    {
        StartCoroutine(WaitAndLoadNextScene());
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSecondsRealtime(LevelManager.TimeToLoadScene);
        LevelManager.LoadNextLevel();
    }

    public void QuitButtonClicked()
    {
        LevelManager.QuitApplication();
    }

    public void BackButtonClicked()
    {
        StartCoroutine(WaitAndLoadPrevScene()); 
    }

    public void ModelSelectionButtonClicked()
    {
        showDetails.ShowModelSelection();
    }

    IEnumerator WaitAndLoadPrevScene()
    {
        yield return new WaitForSecondsRealtime(LevelManager.TimeToLoadScene);
        LevelManager.LoadPrevLevel();
    }
}
