using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GController : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    public InputAction[] inputActions;

    [HideInInspector] public LocationNavigation locationNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInLocation = new List<string>();

    List<string> textLog = new List<string>();


    // Start is called before the first frame update
    void Awake()
    {
        locationNavigation = GetComponent<LocationNavigation>();
    }

    private void Start()
    {
        DisplayLocationText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join(Environment.NewLine, textLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayLocationText()

    {
        ClearConnectionsForNewRoom();

        UnpackLocation();

        string joinedInteractions = string.Join(Environment.NewLine, interactionDescriptionsInLocation.ToArray());

        string combindeText = locationNavigation.currentLocation.description + Environment.NewLine + joinedInteractions;

        LogStringWithReturn(combindeText);
    }

    void UnpackLocation()
    {
        locationNavigation.UnpackExits();
    }

    void ClearConnectionsForNewRoom()
    {
        interactionDescriptionsInLocation.Clear();
        locationNavigation.ClearExits();
    }

    public void LogStringWithReturn(string text)
    {
        textLog.Add(text + Environment.NewLine);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
