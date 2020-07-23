using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Rotate : MonoBehaviour
{
    [SerializeField] GameObject[] animalModels;
    public void RotateObject()
    {
        if(animalModels[0].activeSelf==true)
        {
            animalModels[0].transform.Rotate(Vector3.up*20);
        }
        else if(animalModels[1].activeSelf == true)
        {
            animalModels[1].transform.Rotate(Vector3.up * 20);
        }
        else if(animalModels[2].activeSelf == true)
        {
            animalModels[2].transform.Rotate(Vector3.up * 20);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
