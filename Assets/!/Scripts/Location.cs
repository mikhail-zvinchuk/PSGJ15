using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapAdventure/Location")]
public class Location : ScriptableObject
{
    [TextArea]
    public string description;
    public string locationName;

    public Exit[] exits;
    public InteractableObject[] interactableObjectsInLocation;


}
