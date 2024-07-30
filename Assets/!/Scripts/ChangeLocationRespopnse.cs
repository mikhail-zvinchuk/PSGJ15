using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "MapAdventure/ActionResponses/ChangeRoom")]
public class ChangeLocationRespopnse : ActionResponse
{
    public Location locationToChangeTo;
    

    public override bool DoActionRepsonse(GController controller)
    {
        if (controller.locationNavigation.currentLocation.locationName == requiredString)
        {
            controller.locationNavigation.currentLocation = locationToChangeTo;
            controller.DisplayLocationText();
            controller.PlayDoorSound();
            return true;
        }

        return false;
    }
}
