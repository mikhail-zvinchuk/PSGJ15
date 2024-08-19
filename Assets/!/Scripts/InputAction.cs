using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string keyWord;

    public abstract void RespondToInput(GController controller, string[] separatedInputwords);
}
