using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GController : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    public InputAction[] inputActions;
    public AudioSource doorsoundsource;

    [HideInInspector] public LocationNavigation locationNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInLocation = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
    [HideInInspector] public TextInput textInput;

    List<string> textLog = new List<string>();
    List<string> textColors = new List<string>() { "E1E1E1", "cfcfcf", "b3b3b3", "ababab", "989898", "6d6d6d", "434343" };
    int textColorIndex = 0;

    public int action_count = 0;

    // Start is called before the first frame update
    void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        locationNavigation = GetComponent<LocationNavigation>();
        textInput = GetComponent<TextInput>();
        doorsoundsource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        DisplayLocationText();
        DisplayLoggedText();
    }

    public void IncrementActionCount()
    {
        action_count++;
        if (action_count % 2 == 0)
        {
            textColorIndex++;
            if (textColors.Count <= textColorIndex)
            {
                if (locationNavigation.currentLocation.locationName != "outside")
                {
                    textColorIndex = 0;
                    LogStringWithReturnNoStytle("<color=#E1E1E1> It seems that you can't see anything." + Environment.NewLine + "Shadows take over! " + Environment.NewLine + " You lose.");
                    LogStringWithReturnNoStytle("It took you " + action_count + " actions.");
                    DisplayLoggedText();
                    // Handle lose
                    textInput.ToggleInputField();

                    return;
                }
            }
            
            LogStringWithReturn("It becomes slightly darker 🜖");
        }
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

        if (locationNavigation.currentLocation.locationName == "outside")
        {
            textColorIndex = 0;
            combindeText += "It took you " + action_count + " actions." + Environment.NewLine;
            combindeText += "Congratualtions! you win!" + Environment.NewLine;
            combindeText += "For now..." + Environment.NewLine;
            textInput.ToggleInputField();
        }

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
        string styles = "<color=#" + textColors[textColorIndex] + "><line-height=50%>";
        textLog.Add(styles + text + Environment.NewLine);
    }

    public void LogStringWithReturnNoStytle(string text)
    {
        textLog.Add(text + Environment.NewLine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void PlayDoorSound()
    {
        doorsoundsource.Play();
    }
}
