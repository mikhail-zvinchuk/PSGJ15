using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MapAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        controller.locationNavigation.AttemptToChangeLocations(separatedInputwords[1]);
    }
}
