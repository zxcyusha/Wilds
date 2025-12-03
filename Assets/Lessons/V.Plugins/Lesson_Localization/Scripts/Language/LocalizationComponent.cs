using TMPro;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    public sealed class LocalizationComponent : MonoBehaviour
    {
        [SerializeField] private string key;
        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }


        private void OnEnable()
        {
            text.text = LocalizationManager.GetText(key, LanguageManager.Language);
        }
    }
}