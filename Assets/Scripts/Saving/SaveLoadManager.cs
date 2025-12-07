using Lessons.Plugins.Lesson_Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;
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
    [SerializeField] private Button Sl1;
    [SerializeField] private Button Sl2;
    [SerializeField] private Button Sl3;
    public Sprite Sprite;
    private int CurrentIndex = 0;

    public void Start()
    {
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

        if (fileName == "saved0") Slot1.imagePath1 = Path.Combine(Application.persistentDataPath, "saved0".ToLower() + "_preview.png");
        else if (fileName == "saved1") Slott2.imagePath2 = Path.Combine(Application.persistentDataPath, "saved1".ToLower() + "_preview.png");
        else if (fileName == "saved2") Slott3.imagePath3 = Path.Combine(Application.persistentDataPath, "saved2".ToLower() + "_preview.png");
    }
    public void SaveAll(Texture2D screenshot = null)
    {
        SaveData data = new SaveData();

        GameObject player = GameObject.FindWithTag("Player");

        Vector3 pos = player.transform.position;

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
            if (fileName == "saved0") Slot1.imagePath1 = screenshotPath;
            else if (fileName == "saved1") Slott2.imagePath2 = screenshotPath;
            else if (fileName == "saved2") Slott3.imagePath3 = screenshotPath;
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath, json);
        Debug.Log("Сохранено в файл: " + SavePath);

        data.values.Language = LanguageManager.Language.ToString();
    }

    public void LoadAll()
    {
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

        Debug.Log(saveData.progress.Bird);

        RoomWithRart.CartYes = saveData.progress.Carts;

        BurMachina.BoorSdelali = saveData.progress.Bur;

        Diary.Good = saveData.diary.Good;
        Diary.Bad = saveData.diary.Bad;

        LoadGamee.Valuesensivity = saveData.values.Sensitivity;
        LoadGamee.Valuemusic = saveData.values.MusicValue;
        SceneManager.LoadScene("Game");

       ChangeLanguage.language = saveData.values.Language;
        Debug.Log("ЯЗЫК:" + LanguageManager.Language.ToString());
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
        //slotsView.ChangeSlot(CurrentIndex, Color.red);

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
        fileName = "saved0";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        CurrentIndex = 0;
        GameObject PausePanel = GameObject.FindGameObjectWithTag("Pause");
        PausePanel.SetActive(false);
        GameObject SlotsPanel = GameObject.FindGameObjectWithTag("Slots");
        SlotsPanel.SetActive(false);
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");
    }
    public void Save2()
    {
        fileName = "saved1";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        CurrentIndex = 1;
        GameObject PausePanel = GameObject.FindGameObjectWithTag("Pause");
        PausePanel.SetActive(false);
        GameObject SlotsPanel = GameObject.FindGameObjectWithTag("Slots");
        SlotsPanel.SetActive(false);
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");
    }
    public void Save3()
    {
        fileName = "saved2";
        SavePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        CurrentIndex = 2;
        GameObject PausePanel = GameObject.FindGameObjectWithTag("Pause");
        PausePanel.SetActive(false);
        GameObject SlotsPanel = GameObject.FindGameObjectWithTag("Slots");
        SlotsPanel.SetActive(false);
        StartCoroutine(CaptureScreenshotAndSave());
        SceneManager.LoadScene("MainMenu");

    }

    public void Save()
    {
        StartCoroutine(CaptureScreenshotAndSave());
    }

}
