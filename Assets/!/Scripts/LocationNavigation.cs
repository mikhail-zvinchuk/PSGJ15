using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationNavigation : MonoBehaviour
{
    public Location currentLocation;

    Dictionary<string, Location> exitDictinary = new Dictionary<string, Location>();
    GController controller;

    private void Awake()
    {
        controller = GetComponent<GController>();

    }


    public void UnpackExits()
    {
        for (int i = 0; i < currentLocation.exits.Length; i++)
        {
            exitDictinary.Add(currentLocation.exits[i].keyString, currentLocation.exits[i].valueLocation);
            controller.interactionDescriptionsInLocation.Add(currentLocation.exits[i].exitDescription);
        }
    }


    public void AttemptToChangeLocations(string directionNoun)
    {
        if (exitDictinary.ContainsKey(directionNoun))
        {
            currentLocation = exitDictinary[directionNoun];
            controller.LogStringWithReturn("You head off to the " + directionNoun);
            controller.DisplayLocationText();
        }
        else
        {
            controller.LogStringWithReturn("You can't get to " + directionNoun);
        }
    }


    public void ClearExits()
    {
        exitDictinary.Clear();
    }
}
