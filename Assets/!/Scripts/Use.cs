using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MapAdventure/InputActions/Use")]
public class Use : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        controller.interactableItems.UseItem(separatedInputwords);
    }
}
