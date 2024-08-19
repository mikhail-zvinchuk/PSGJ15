using UnityEngine;


[CreateAssetMenu(menuName = "MapAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        if (separatedInputwords.Length >= 2)
        {
            controller.LogStringWithReturn(controller.TestVerbDirctinaryWithNoun(controller.interactableItems.examineDictionary, separatedInputwords[0], separatedInputwords[1]));
        }
    }
}
