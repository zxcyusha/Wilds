using System;
using TMPro;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [Serializable]
    public sealed class TextLanguageListener
    {
        private TextMeshProUGUI text;

        [SerializeField]
        private string key;

        // void ILanguageListener.OnLanguageChanged(SystemLanguage language)
        // {
        //     text.text = LocalizationManager.GetText(key, language);
        // }
        
        public void OnLanguageChanged(SystemLanguage language)
        {
            text.text = LocalizationManager.GetText(key, language);
        }
        public void SetText(TextMeshProUGUI textik)
        {
            text = textik;
        }
    }
}