using UnityEngine;

[CreateAssetMenu(menuName = "MapAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    [TextArea]
    public string description = "Description in room";

    public Interaction[] interactions;
}
