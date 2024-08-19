using UnityEngine;

public abstract class ActionResponse : ScriptableObject
{
    public string requiredString;
    public abstract bool DoActionRepsonse(GController controller);
}
