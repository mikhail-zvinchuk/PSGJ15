using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GController : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    public InputAction[] inputActions;

    [HideInInspector] public LocationNavigation locationNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInLocation = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;

    List<string> textLog = new List<string>();


    // Start is called before the first frame update
    void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        locationNavigation = GetComponent<LocationNavigation>();
    }

    private void Start()
    {
        DisplayLocationText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join(Environment.NewLine, textLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayLocationText()

    {
        ClearConnectionsForNewRoom();

        UnpackLocation();

        string joinedInteractions = string.Join(Environment.NewLine, interactionDescriptionsInLocation.ToArray());

        string combindeText = locationNavigation.currentLocation.description + Environment.NewLine + joinedInteractions;

        LogStringWithReturn(combindeText);
    }

    void UnpackLocation()
    {
        locationNavigation.UnpackExits();
        PrepareObjectsForInteraction(locationNavigation.currentLocation);
    }

    void PrepareObjectsForInteraction(Location location)
    {
        foreach (var interactableObject in location.interactableObjectsInLocation) { 
            string descriptonNotInInventory = interactableItems.GetObjectsNotInInventory(interactableObject);
            if (descriptonNotInInventory != null)
            {
                interactionDescriptionsInLocation.Add(descriptonNotInInventory);
            }

            foreach (var interaction in interactableObject.interactions)
            {
                switch (interaction.action.keyWord)
                {
                    case "examine":
                        interactableItems.examineDictionary.Add(interactableObject.noun, interaction.textResponse);
                        break;
                    case "take":
                        interactableItems.takeDictionary.Add(interactableObject.noun, interaction.textResponse);
                        break;
                }
            }
        }
    }


    public string TestVerbDirctinaryWithNoun(Dictionary<string, string> verbDictinary, string verb, string noun)
    {
        if (verbDictinary.ContainsKey(noun))
        {
            return verbDictinary[noun];
        }

        return "You can't " + verb + " " + noun;
    }

    void ClearConnectionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactionDescriptionsInLocation.Clear();
        locationNavigation.ClearExits();
    }

    public void LogStringWithReturn(string text)
    {
        textLog.Add(text + Environment.NewLine);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
