using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ShowModel : MonoBehaviour
{
    [SerializeField] GameObject[] AnimalModels;
    [SerializeField] GameObject AnimalDetailsContainer;

    List<Vector3> originalRotation=new List<Vector3>();
    List<Transform> AnimalDetails= new List<Transform>();
    private void Awake()
    {
        foreach(GameObject model in AnimalModels)
        {
            originalRotation.Add(model.transform.eulerAngles);
        }
    }
    void Start()
    {
        foreach(Transform transform in AnimalDetailsContainer.transform)
        {
            AnimalDetails.Add(transform);
        }
    }

    public void CaptureButtonName()
    {
        DisplayModel(EventSystem.current.currentSelectedGameObject.name);
    }

    void DisplayModel(string name)
    {
        int index = 0;
        foreach(GameObject model in AnimalModels)
        {
            model.transform.eulerAngles = originalRotation[index];
            AnimalDetails[index].gameObject.SetActive(false);
            model.SetActive(false);
            index++;
        }
        switch(name)
        {
            case "DogButton":
                {
                    SetModelAndDetailsActive(0);
                    break;
                }
            case "DeerButton":
                {
                    SetModelAndDetailsActive(1);
                    break;
                }
            case "OrangutanButton":
                {
                    SetModelAndDetailsActive(2);
                    break;
                }
        }
    }

    private void SetModelAndDetailsActive(int value)
    {
        AnimalDetails[value].gameObject.SetActive(true);
        AnimalModels[value].SetActive(true);
    }
}
