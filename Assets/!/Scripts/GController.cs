using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GController : MonoBehaviour
{

    public TextMeshProUGUI displayText;

    [HideInInspector] public LocationNavigation locationNavigation;

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
        string combindeText = locationNavigation.currentLocation.description + Environment.NewLine;

        LogStringWithReturn(combindeText);
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
