using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemsList;

    public Dictionary<string, string> examineDictionary = new();
    public Dictionary<string, string> takeDictionary = new();

    [HideInInspector] public List<string> nounsInLocation = new();



    readonly Dictionary<string, ActionResponse> useDictionary = new();
    readonly List<string> nounsInInventory = new();

    GController controller;

    void Awake()
    {
        controller = GetComponent<GController>();
    }


    public string GetObjectsNotInInventory(InteractableObject interactable)
    {
        if (!nounsInInventory.Contains(interactable.noun))
        {
            nounsInLocation.Add(interactable.noun);
            return interactable.description;
        }

        return null;
    }

    public void AddActionResponsesTOUseDictionary()
    {
        foreach (var noun in nounsInInventory)
        {
            var interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if (interactableObjectInInventory == null)
            {
                continue;
            }
            else
            {
                foreach (var interaction in interactableObjectInInventory.interactions)
                {
                    if (interaction.actionResponse == null)
                        continue;

                    if (!useDictionary.ContainsKey(noun))
                    {
                        useDictionary.Add(noun, interaction.actionResponse);
                    }
                }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        foreach (var item in usableItemsList)
        {
            if (item.noun == noun)
            {
                return item;
            }

        }

        return null;
    }


    public void DisplayInventory()
    {
        if (nounsInInventory.Any())
        {
            controller.LogStringWithReturn("You have:");
            foreach (var item in nounsInInventory)
            {
                controller.LogStringWithReturn(item);

            }
        }
        else
        {
            controller.LogStringWithReturn("You don't have anything with you apart your basic clothes.");
        }


    }

    public void ClearCollections()
    {
        examineDictionary.Clear();
        nounsInLocation.Clear();
        takeDictionary.Clear();
    }

    // Mayeb add a random appearing user created item. First time for sure and them random.  item isn't really avalible for anything, but if player has it they can get soem quest or something.
    // Maybe use all unknown words that player types as something, like they are midas but just words start existing. 


    /// <summary>
    /// 
    /// </summary>
    /// <param name="separatedInputWords"></param>
    /// <returns></returns>
    public Dictionary<string, string> Take(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        if (nounsInLocation.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesTOUseDictionary();
            nounsInLocation.Remove(noun);
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn("There is no " + noun + " here to take.");
            return null;
        }


    }

    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1];
        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDictionary.ContainsKey(nounToUse))
            {
                var actionResult = useDictionary[nounToUse].DoActionRepsonse(controller);
                if (!actionResult)
                {
                    controller.LogStringWithReturn("Hmm. Nothing happens.");
                }
            }
            else
            {
                controller.LogStringWithReturn("You can't use the " + nounToUse);
            }
        }
        else
        {
            controller.LogStringWithReturn("There is no " + nounToUse + " in your inventory");
        }
    }
}
