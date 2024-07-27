using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapAdventure/InputActions/Take")]
public class Take : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        if (separatedInputwords.Length >= 2)
        {
            Dictionary<string, string> takeDictionary = controller.interactableItems.Take(separatedInputwords);
            if (takeDictionary != null)
            {
                controller.LogStringWithReturn(controller.TestVerbDirctinaryWithNoun(takeDictionary, separatedInputwords[0], separatedInputwords[1]));
            }
        }
    }
}
