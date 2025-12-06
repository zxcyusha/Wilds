using Lessons.Plugins.Lesson_Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    private string fileName = "saved0";
    private string SavePath;
    public static Vector3 PlayerPosition;
    [SerializeField] private Slider SensitivitySlider;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private SavedSlotsView slotsView;
    [SerializeField] private Button Slot1;
    [SerializeField] private Button Slot2;
    [SerializeField] private Button Slot3;
    [SerializeField] private Button Sl1;
    [SerializeField] private Button Sl2;
    [SerializeField] private Button Sl3;
    public Sprite Sprite;
    private int CurrentIndex = 0;

    public void Start()
    {
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
    }
    public void SaveAll(Texture2D screenshot = null)
    {
        SaveData data = new SaveData();

        GameObject player = GameObject.FindWithTag("Player");

        Vector3 pos = player.transform.position;
        Debug.Log(pos);

        data.player.position = new float[] {pos.x, pos.y, pos.z};
        data.day.currentDay = DAYS.day;
        data.diary.Good = Diary.Good;
        data.diary.Bad = Diary.Bad;

        data.progress.Bird = Nanometr.PODKYTILI1 && Nanometr1.PODKYTILI2 && Nanometr2.PODKYTILI3;
        data.progress.Otchet = TakeListok.vibrali1 && TakeListok.vibrali2 && TakeListok.vibrali3 && TakeListok.vibrali4 && TakeListok.vibrali5;
        data.progress.Carts = RoomWithRart.CartYes;
        data.progress.Bur = BurMachina.BoorSdelali;

        data.values.Sensitivity = SensitivitySlider.value;
        data.values.MusicValue = MusicSlider.value;

        data.saveName = fileName;
        data.saveTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        if (screenshot != null)
        {
            byte[] bytes = screenshot.EncodeToPNG();
            var sprite = Sprite.Create(
            screenshot,
            new Rect(0, 0, screenshot.width, screenshot.height),
            new Vector2(0.5f, 0.5f),
            100f
        );
            string screenshotPath = Path.Combine(Application.persistentDataPath, fileName.ToLower() + "_preview.png");
            File.WriteAllBytes(screenshotPath, bytes);

            Debug.Log("Скриншот сохранен: " + screenshotPath);
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        Debug.Log("Сохранено в файл: " + SavePath);

        data.values.Language = LanguageManager.Language;
    }

    public void LoadAll()
    {
        Debug.Log(SavePath);
        if (!File.Exists(SavePath))
        {
            Debug.Log("Не существует такого файла");
            return;
        }
        string json = File.ReadAllText(SavePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        PlayerPosition = new Vector3(saveData.player.position[0], saveData.player.position[1], saveData.player.position[2]);

        LoadGamee.PlayerPos = PlayerPosition;

        DAYS.day = saveData.day.currentDay;

        Nanometr.PODKYTILI1 = saveData.progress.Bird;
        Nanometr1.PODKYTILI2 = saveData.progress.Bird;
        Nanometr2.PODKYTILI3 = saveData.progress.Bird;

        RoomWithRart.CartYes = saveData.progress.Carts;

        BurMachina.BoorSdelali = saveData.progress.Bur;

        Diary.Good = saveData.diary.Good;
        Diary.Bad = saveData.diary.Bad;

        LoadGamee.Valuesensivity = saveData.values.Sensitivity;
        LoadGamee.Valuemusic = saveData.values.MusicValue;
        SceneManager.LoadScene("Game");

       LanguageManager.Language = saveData.values.Language;
    }


    public IEnumerator CaptureScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        var sprite = Sprite.Create(
            screenshot,
            new Rect(0, 0, screenshot.width, screenshot.height),
            new Vector2(0.5f, 0.5f),
            100f
        );
        //slotsView.ChangeSlot(CurrentIndex, Sprite);

        SaveAll(screenshot);
    }


    public void LoadGameByIndex(int index)
    {
        fileName = "saved" + index;
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        LoadAll();
    }

    public void Kn1()
    {
        LoadGameByIndex(0);
    }
    public void Kn2()
    {
        LoadGameByIndex(1);
    }
    public void Kn3()
    {
        LoadGameByIndex(2);
    }

    public void Save1()
    {
        Debug.Log(0);
        fileName = "saved0";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");
        CurrentIndex = 0;
    }
    public void Save2()
    {
        fileName = "saved1";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");
        CurrentIndex = 1;
    }
    public void Save3()
    {
        fileName = "saved2";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");
        CurrentIndex = 2;

    }

    public void Save()
    {
        StartCoroutine(CaptureScreenshotAndSave());
    }

}
