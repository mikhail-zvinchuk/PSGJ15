using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{

    public void ToggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
