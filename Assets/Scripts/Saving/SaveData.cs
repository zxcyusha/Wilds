using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    [Serializable]
    public class PlayerData
    {
        public float[] position;
    }

    [Serializable]
    public class DayData
    {
        public int currentDay;
    }

    [Serializable]
    public class DiaryData
    {
        public int Good;
        public int Bad;
    }

    [Serializable]
    public class DayProgess
    {
        public bool Bird;
        public bool Carts;
        public bool Otchet;
        public bool Bur;
    }

    [Serializable]
    public class SettingsValues
    {
        public string Language;
        public float MusicValue;
        public float Sensitivity;
    }

    public PlayerData player = new PlayerData();
    public DayData day = new DayData();
    public DiaryData diary = new DiaryData();
    public DayProgess progress = new DayProgess();
    public SettingsValues values = new SettingsValues();
    public string saveName;   // имя сейва
    public string saveTime;   // время сохранения, текстом
}