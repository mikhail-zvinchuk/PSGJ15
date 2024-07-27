using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();

    [HideInInspector] public List<string> nounsInLocation = new List<string>();

    List<string> nounsInInventory = new List<string>();

    GController controller;

    void Awake() { 
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

    public void DisplayInventory()
    {
        controller.LogStringWithReturn("You have:");
        foreach (var item in nounsInInventory)
        {
            controller.LogStringWithReturn(item);

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
            nounsInLocation.Remove(noun);
            return takeDictionary;
        } else
        {
            controller.LogStringWithReturn("There is no " + noun + " here to take.");
            return null;
        }

      
    }
}
