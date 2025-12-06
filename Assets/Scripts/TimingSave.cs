using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimingSave : MonoBehaviour
{
    public string filePath;
    public TextMeshProUGUI textik;

    void Start()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, filePath);

        if (File.Exists(fullPath))
        {
            try
            {
                string json = File.ReadAllText(fullPath);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                textik.text = data.saveTime;
                //Debug.Log("saveTime: " + data.saveTime);
            }
            catch (Exception e)
            {
                Debug.LogError("Ошибка чтения JSON: " + e.Message);
            }
        }
        else
        {
            Debug.LogWarning("Файл не найден по пути: " + fullPath);
        }
    }
}
