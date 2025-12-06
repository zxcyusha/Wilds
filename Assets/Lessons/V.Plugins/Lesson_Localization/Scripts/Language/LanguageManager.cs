using System;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LanguageManager : MonoBehaviour
    {
        public static event Action<SystemLanguage> OnLanguageChanged;

        public static SystemLanguage Language
        {
            get { return GetLanguage(); }
            set { SetLanguage(value); }
        }

        private static LanguageManager instance;

        private SystemLanguage language;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance != null)
            {
                throw new Exception("Language Manager is already exists!");
            }

            instance = this;
            
            var initialLanguage = Application.systemLanguage;
            language = initialLanguage;
            OnLanguageChanged?.Invoke(initialLanguage);
        }

        private void Update()
        {
            Debug.Log(LanguageManager.Language.ToString() == "Russian");
        }
        private void OnDestroy()
        {
            instance = null;
        }

        private static void SetLanguage(SystemLanguage value)
        {
            if (instance != null)
            {
                instance.language = value;
                OnLanguageChanged?.Invoke(value);
            }
        }
        
        private static SystemLanguage GetLanguage()
        {
            if (instance != null)
            {
                return instance.language;
            }

            return default;
        }

#if UNITY_EDITOR
        private void SetLanguageInEditor(SystemLanguage value)
        {
            Debug.Log($"Language changed {value}");
            language = value;
            OnLanguageChanged?.Invoke(value);
        }
#endif
    }
}