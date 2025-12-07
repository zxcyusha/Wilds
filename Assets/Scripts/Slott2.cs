using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Slott2 : MonoBehaviour
{
    public Image targetImage;
    public static string imagePath2;

    void Start()
    {
        imagePath2 = Path.Combine(Application.persistentDataPath, "saved1".ToLower() + "_preview.png");
        LoadImageFromFile2();
    }
    public void LoadImageFromFile2()
    {
        if (File.Exists(imagePath2))
        {
            byte[] fileData = File.ReadAllBytes(imagePath2);
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
            Debug.LogWarning("Файл не найден по указанному пути: " + imagePath2);
        }
    }

    Sprite SpriteFromTexture(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                             new Vector2(0.5f, 0.5f));
    }
}
