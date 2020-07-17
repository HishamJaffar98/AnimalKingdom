using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowDetails : MonoBehaviour
{
    [Header("Part Information Support")]
    [SerializeField] TextMeshProUGUI partNameText;
    [SerializeField] TextMeshProUGUI partInfo;

    [Header("Part information Data")]
    [SerializeField] PartDetails partDetailsObject;

    [Header("Display Objects")]
    [SerializeField] GameObject buttonsContainer;
    [SerializeField] GameObject informationPanel;
    [SerializeField] GameObject modelSelectionButton;

    [SerializeField] GameObject[] models;

    string[] partDetails;
    Coroutine co;
    float characterDelay;
    bool isViewingOrgan;
    int viewingOrgan;
    float smoothSpeed;
    Vector3 dogRotation;
    float mainCameraFOV;
    Vector3 mainCameraOGPos;
    Vector3 mainCameraOGRot;

    public bool IsViewingOrgan
    {
        get
        {
            return isViewingOrgan;
        }
    }

    private void Awake()
    {
        characterDelay = 0.04f;
        mainCameraFOV = Camera.main.GetComponent<Camera>().fieldOfView;
        mainCameraOGPos = Camera.main.transform.position;
        mainCameraOGRot = Camera.main.transform.eulerAngles;
        
    }

    private void Start()
    {
        smoothSpeed = 0f;
        partDetails = partDetailsObject.PartsDetails;
        isViewingOrgan = false;
    }

    void Update()
    {
        print(models[0].transform.localEulerAngles.y);
        if(Input.touchCount>0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if(firstTouch.phase==TouchPhase.Stationary)
            {
                characterDelay = 0.001f;
            }
            else if(firstTouch.phase==TouchPhase.Ended)
            {
                characterDelay = 0.04f;
            }
        }
        if(IsViewingOrgan==false)
        {
            return;
        }
        switch(viewingOrgan)
        {
            case 1:
                ZoomIntoOrgan(12, new Vector3(15.9f, 0, 0), 235.3f, 0);
                break;
            case 2:
                ZoomIntoOrgan(14, new Vector3(11.9f, 0, 0), 261.8f, 0);
                break;
            case 3:
                ZoomIntoOrgan(18, new Vector3(24.8f, 0, 0), 30.07f, 0);
                break;
            case 4:
                ZoomIntoOrgan(19, new Vector3(6.58f, 353.58f, 0), 72.8f, 1);
                break;
            case 5:
                ZoomIntoOrgan(20, new Vector3(18.64f, 332.95f, 348.8f), 240.8f, 1);
                break;
            case 6:
                ZoomIntoOrgan(27, new Vector3(39.9f, 338.4f, 346.2f), 240.8f, 1);
                break;
            case 7:
                ZoomIntoOrgan(21, new Vector3(359f, 345.12f, 349.28f), 270.78f, 2);
                break;
            case 8:
                ZoomIntoOrgan(42, new Vector3(28.09f, 350f, 353.9f), 243.37f, 2);
                break;
            case 9:
                ZoomIntoOrgan(20, new Vector3(33f, 326f, 338.8f), 200f, 2);
                break;
        }
    }

    public void ShowModelSelection()
    {
        Camera.main.GetComponent<Camera>().fieldOfView = mainCameraFOV;
        Camera.main.transform.eulerAngles = mainCameraOGRot;
        HideAndShowElements(true, false);
    }

    void ZoomIntoOrgan(int fov, Vector3 cameraRot, float modelRotY, int modelIndex)
    {
        smoothSpeed += Time.deltaTime;
        Camera.main.gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(mainCameraFOV, fov, smoothSpeed);
        float step = 30 * Time.deltaTime;
        Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, Quaternion.Euler(cameraRot), smoothSpeed*30);
        models[modelIndex].transform.localEulerAngles = new Vector3(0, Mathf.Lerp(models[modelIndex].transform.localEulerAngles.y, modelRotY, smoothSpeed), 0);
    }
    public void ProcessDetails()
    {
        smoothSpeed = 0;
        if(buttonsContainer.activeSelf==true)
        {
            HideAndShowElements(false,true);
        }
        if(co!=null)
        {
            StopCoroutine(co);
        }
        DisplayDetails(EventSystem.current.currentSelectedGameObject.name);
    } 

    private void HideAndShowElements(bool trigger1, bool trigger2)
    {
        if (trigger1==false)
        {
            isViewingOrgan = true;
        }
        else if(trigger1==true)
        {
            isViewingOrgan = false;
        }
        buttonsContainer.SetActive(trigger1);
        informationPanel.SetActive(trigger2);
        if(trigger2==false)
        {
            modelSelectionButton.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        modelSelectionButton.SetActive(trigger2);
    }

    private void DisplayDetails(string name)
    {
       switch(name)
        {
            case "DogEarButton":
                FillDetails("EAR",0);
                break;
            case "DogNoseButton":
                FillDetails("NOSE", 1);
                break;
            case "DogTailButton":
                FillDetails("TAIL", 2);
                break;
            case "DeerAntlersButton":
                FillDetails("ANTLERS", 3);
                break;
            case "DeerTrunkButton":
                FillDetails("TRUNK", 4);
                break;
            case "DeerHoovesButton":
                FillDetails("HOOVES", 5);
                break;
            case "OrangutanCheeksButton":
                FillDetails("CHEEKS", 6);
                break;
            case "OrangutanArmsButton":
                FillDetails("ARMS", 7);
                break;
            case "OrangutanFeetButton":
                FillDetails("FEET", 8);
                break;
        }
    }

    private void FillDetails(string partName, int index)
    {
        viewingOrgan = index+1;
        partNameText.text = partName;
        co=StartCoroutine(WaitAndTypeInfo(index));
    }

    IEnumerator WaitAndTypeInfo(int index)
    {
        partInfo.text = "";
        string partText = "";
        partText = partDetails[index];
        foreach (char a in partText)
        {
            partInfo.text += a;
            yield return new WaitForSeconds(characterDelay);
        }
    }
}
