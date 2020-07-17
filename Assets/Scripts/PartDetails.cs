using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(menuName = "Details")]
public class PartDetails : ScriptableObject
{
    [SerializeField] string[] partsDetails;
    
    public string[] PartsDetails
    {
        get
        {
            return partsDetails;
        }
    }
}
