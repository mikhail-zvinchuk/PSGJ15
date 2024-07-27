using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        if (separatedInputwords.Length >= 2)
        {
            controller.locationNavigation.AttemptToChangeLocations(separatedInputwords[1]);
        }
    }
}
