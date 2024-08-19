using TMPro;
using UnityEngine;

public class TextToggler : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ToggleText()
    {

        if (text.text == "unmute")
        {
            text.text = "mute";
        }
        else
        {
            text.text = "unmute";
        }
    }
}
