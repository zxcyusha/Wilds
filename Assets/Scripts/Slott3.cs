using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Slott3 : MonoBehaviour
{
    public Image targetImage;
    public static string imagePath3;

    void Start()
    {
        imagePath3 = Path.Combine(Application.persistentDataPath, "saved2".ToLower() + "_preview.png");
        LoadImageFromFile3();
    }
    public void LoadImageFromFile3()
    {
        if (File.Exists(imagePath3))
        {
            Debug.Log("ABOBA3 =" + imagePath3);
            byte[] fileData = File.ReadAllBytes(imagePath3);
            Texture2D tex = new Texture2D(2, 2);
            if (tex.LoadImage(fileData))
            {
                Sprite sprite = SpriteFromTexture(tex);
                targetImage.sprite = sprite;
                Debug.Log("Изображение успешно загружено и установлено.");
            }
            else
            {
                Debug.LogWarning("Не удалось загрузить изображение из файла.");
            }
        }
        else
        {
            Debug.LogWarning("Файл не найден по указанному пути: " + imagePath3);
        }
    }

    Sprite SpriteFromTexture(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                             new Vector2(0.5f, 0.5f));
    }
}