
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    private string saveFolder;   // Папка для сохранений
    private string autoSaveFile; // Путь к автосейву

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Создаём папку для сохранений в месте приложения (persistentDataPath)
            saveFolder = Path.Combine(Application.persistentDataPath, "Saves");
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            autoSaveFile = Path.Combine(saveFolder, "autosave.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Сохраняем прогресс в JSON
    public void SaveGame(string saveName = "autosave", Texture2D screenshot = null)
    {
        SaveData data = new SaveData();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            data.player.position = new float[] { pos.x, pos.y, pos.z };
        }

        data.day.currentDay = DAYS.day;

        data.diary.Good = Diary.Good;
        data.diary.Bad = Diary.Bad;

        data.catScene.Bird = Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3;
        data.catScene.Bur = BurMachina.BoorSdelali;
        data.catScene.Report = TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5;
        data.catScene.Carts = RoomWithRart.CartYes;

        data.saveName = saveName;
        data.saveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string json = JsonUtility.ToJson(data, true); // true = форматированный

        string fileName = saveName.ToLower() + ".json";
        string path = Path.Combine(saveFolder, fileName);

        File.WriteAllText(path, json);
        Debug.Log($"Сохранено: {path}");

        if (screenshot != null)
        {
            byte[] bytes = screenshot.EncodeToPNG();
            string screenshotPath = Path.Combine(saveFolder, saveName.ToLower() + "_preview.png");
            File.WriteAllBytes(screenshotPath, bytes);
            Debug.Log("Скриншот сохранен: " + screenshotPath);
        }
    }

    // Загружаем данные из JSON
    public SaveData LoadGame(string saveName = "autosave")
    {
        string fileName = saveName.ToLower() + ".json";
        string path = Path.Combine(saveFolder, fileName);

        if (!File.Exists(path))
        {
            Debug.LogWarning("Файл сохранения не найден: " + path);
            return null;
        }

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data;
    }

    // Пример применения загруженных данных
    public void ApplySaveData(SaveData data)
    {
        if (data == null) return;

        // Позиция игрока
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && data.player.position != null && data.player.position.Length == 3)
        {
            player.transform.position = new Vector3(data.player.position[0], data.player.position[1], data.player.position[2]);
        }


        DAYS.day = data.day.currentDay;
        Diary.Good = data.diary.Good;
        Diary.Bad = data.diary.Bad;

        Nanometr.PODKYTILI1 = data.catScene.Bird;
        Nanometr1.PODKYTILI2 = data.catScene.Bird;
        Nanometr2.PODKYTILI3 = data.catScene.Bird;

        BurMachina.BoorSdelali = data.catScene.Bur;
        TakeListok.vibrali1 = data.catScene.Report;
        TakeListok.vibrali2 = data.catScene.Report;
        TakeListok.vibrali3 = data.catScene.Report;
        TakeListok.vibrali4 = data.catScene.Report;
        TakeListok.vibrali5 = data.catScene.Report;

        RoomWithRart.CartYes = data.catScene.Carts;

        data.catScene.Carts = RoomWithRart.CartYes;
    }

    // Метод для автосохранения перед выходом
    private void OnApplicationQuit()
    {
        SaveGame("autosave");
    }
}
 
