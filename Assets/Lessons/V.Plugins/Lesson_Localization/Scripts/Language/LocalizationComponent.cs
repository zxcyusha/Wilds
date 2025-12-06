using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LocalizationComponent : MonoBehaviour
    {
        // [SerializeReference]
        // private ILanguageListener[] _listeners;
        
        [SerializeField]
        private TextLanguageListener[] _listeners;
    
        private void OnEnable()
        {
            UpdateLanguage(LanguageManager.Language);
            LanguageManager.OnLanguageChanged += UpdateLanguage;
        }

        private void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= UpdateLanguage;            
        }

        private void UpdateLanguage(SystemLanguage language)
        {
            foreach (var listener in _listeners)
            {
                listener.OnLanguageChanged(language);
            }
        }
    }
}