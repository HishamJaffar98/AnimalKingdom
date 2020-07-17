using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotationFactor = 100;
    float touchPositionX;
    ShowDetails showDetails;
    void Start()
    {
        showDetails = FindObjectOfType<ShowDetails>();
    }

    // Update is called once per frame

    void Update()
    {
        print(showDetails.IsViewingOrgan);
        if(showDetails.IsViewingOrgan==true)
        {
            return;
        }
        if (Input.touchCount>0)
        {
            Touch firstTouch = Input.GetTouch(0);
            
            if(firstTouch.phase ==  TouchPhase.Moved)
            {
                Vector3 direction = firstTouch.deltaPosition.normalized;
                float xdirection = direction.x;
                float speed = xdirection / firstTouch.deltaTime;
                if (xdirection>0)
                {
                    transform.Rotate(Vector3.down,firstTouch.deltaPosition.x*rotationFactor * Time.deltaTime);
                }
                else if (xdirection<0)
                {
                    transform.Rotate(Vector3.down, firstTouch.deltaPosition.x*rotationFactor*Time.deltaTime);
                }
            }
        }
    }
}
