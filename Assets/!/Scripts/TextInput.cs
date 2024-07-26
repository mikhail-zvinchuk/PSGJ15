using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputField;

    GController controller;

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


        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction action = controller.inputActions[i];
            if (action != null) {
                action.RespondToInput(controller, separatedInputWords);
            }

        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

}
