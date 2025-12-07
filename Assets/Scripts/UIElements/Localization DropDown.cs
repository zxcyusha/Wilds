using Lessons.Plugins.Lesson_Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        SaveData data11 = new SaveData();

        string path = Path.Combine(Application.persistentDataPath, "saved".ToLower() + ".json");
        if (LanguageManager.Language.ToString() == "Russian") data11.values.Language = "Russian";
        else if (LanguageManager.Language.ToString() == "English") data11.values.Language = "English";
        string json1 = JsonUtility.ToJson(data11);
        File.WriteAllText(path, json1);

        if (File.Exists(path))
        {
            string jsonchik = File.ReadAllText(path);
            SaveData datochka = JsonUtility.FromJson<SaveData>(jsonchik);
            if (datochka.values.Language == "Russian") LanguageManager.Language = SystemLanguage.Russian;
            else if (datochka.values.Language == "English") LanguageManager.Language = SystemLanguage.English;
        }
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