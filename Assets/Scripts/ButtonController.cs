using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    ShowDetails showDetails;
    GameObject narrator;
    public void Start()
    {
        narrator = GameObject.FindGameObjectWithTag("Narrator");
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
        if(FindObjectOfType<MusicPlayer>()!=null)
        {
            FindObjectOfType<MusicPlayer>().gameObject.GetComponent<AudioSource>().volume = 0.2f;
        }
        narrator.GetComponent<AudioSource>().Stop();
        StartCoroutine(WaitAndLoadPrevScene()); 
    }

    public void ModelSelectionButtonClicked()
    {
        narrator.GetComponent<AudioSource>().Stop();
        showDetails.ShowModelSelection();
    }
    IEnumerator WaitAndLoadPrevScene()
    {
        yield return new WaitForSecondsRealtime(LevelManager.TimeToLoadScene);
        LevelManager.LoadPrevLevel();
    }
}
