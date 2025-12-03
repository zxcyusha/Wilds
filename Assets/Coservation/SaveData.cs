
using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    [Serializable]
    public class PlayerData
    {
        public float[] position; // [x, y, z]
    }

    [Serializable]
    public class DayData
    {
        public int currentDay; // 1, 2, ... 5
    }

    [Serializable]
    public class DiaryData
    {
        public int Good;
        public int Bad;
    }

    [Serializable]
    public class CatSceneData
    {
        public bool Bird;
        public bool Bur;
        public bool Report;
        public bool Carts;
    }

    public PlayerData player = new PlayerData();
    public DayData day = new DayData();
    public DiaryData diary = new DiaryData();
    public CatSceneData catScene = new CatSceneData();

    public string saveName;   // имя сейва
    public string saveTime;   // время сохранения, текстом
}
