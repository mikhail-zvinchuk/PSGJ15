using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationNavigation : MonoBehaviour
{
    public Location currentLocation;

    GController controller;

    private void Awake()
    {
        controller = GetComponent<GController>();
        
    }


    public void UnpackExits()
    {
        for (int i = 0; i < currentLocation.exits.Length; i++)
        {
            controller.interactionDescriptionsInLocation.Add(currentLocation.exits[i].exitDescription);
        }
    }
}
