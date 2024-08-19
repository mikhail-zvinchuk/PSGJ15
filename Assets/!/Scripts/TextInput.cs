using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;

    GController controller;

    readonly List<string> iDontUnderstands = new() { "🜈🜈hat ? Non capisco, Prova qualcos'altro", "🜈🜈hat ? Non intellego, Try aliquid aliud", "🜈🜈hat ? Capissi minga, pruva quaicos d’olter", "🜈🜈hat ? Chan eil mi a’ tuigsinn, Feuch rudeigin eile" };



    private void Awake()
    {
        controller = GetComponent<GController>();
        inputField.onEndEdit.AddListener(AcceptrStringInput);
    }

    void AcceptrStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimeterCharacters = { ' ' };
        string[] separatedInputWords = userInput.Split(delimeterCharacters);

        bool handled = false;
        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction action = controller.inputActions[i];
            if (action.keyWord == separatedInputWords[0])
            {
                action.RespondToInput(controller, separatedInputWords);
                handled = true;
            }

        }

        if (!handled)
        {

            controller.LogStringWithReturn(iDontUnderstands[Random.Range(0, iDontUnderstands.Count - 1)]);
        }

        InputComplete();
    }

    public void ToggleInputField()
    {
        inputField.enabled = !inputField.enabled;
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
        controller.IncrementActionCount();
    }

}
