using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Globalization;

public class InfoUI_DateTime : MonoBehaviour, IInfoUI_TextLabel
{
    public string DateTimeFormat = "";

    public TextMeshProUGUI textMesh;

    [SerializeField]
    private string _defaultValue;

    [SerializeField]
    private string _label;

    public string Text
    {
        set
        {
            textMesh.text = ConvertTextToDateTime(value);
        }
    }

    public string DefaultValue
    {
        get
        {
            return _defaultValue;
        }

        set { }
    }

    public string Label { get { return _label; } set { _label = value; } }

    void Awake()
    {
        if (textMesh != null) textMesh = GetComponent<TextMeshProUGUI>();
    }

    string ConvertTextToDateTime(string text)
    {
        try
        {
            DateTime dateFromString = DateTime.ParseExact(text, DateTimeFormat, CultureInfo.InvariantCulture);
            DateTime localTime = dateFromString.ToLocalTime();

            return localTime.ToString(DateTimeFormat);
        }
        catch (Exception e)
        {
            return text;
        }
    }
}
