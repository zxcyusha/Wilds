using Lessons.Plugins.Lesson_Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LocalisationDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    void Awake()
    {
        dropdown.RefreshShownValue();

        dropdown.onValueChanged.AddListener(OnChanged);
    }

    void OnChanged(int index)
    {
        var code = GetCodeByOption(index);
        LanguageManager.Language = code;
    }

    SystemLanguage GetIndexByCode(string code)
    {
        switch (code)
        {
            case "ru": return SystemLanguage.Russian;
            case "en": return SystemLanguage.English;
            default: return 0;
        }
    }

    SystemLanguage GetCodeByOption(int index)
    {
        var label = dropdown.options[index].text;
        if (label == "Русский")
        {
            return SystemLanguage.Russian;
        }
        else return SystemLanguage.English;
        
    }
}