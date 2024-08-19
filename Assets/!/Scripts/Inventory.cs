using UnityEngine;


[CreateAssetMenu(menuName = "MapAdventure/InputActions/Inventory")]
public class Inventory : InputAction
{
    public override void RespondToInput(GController controller, string[] separatedInputwords)
    {
        controller.interactableItems.DisplayInventory();
    }
}
