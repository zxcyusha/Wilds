
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Slot1 : MonoBehaviour
{
    public Image targetImage;
    public static string imagePath1;

    void Start()
    {
        LoadImageFromFile1();
    }

    public void LoadImageFromFile1()
    {
        if (File.Exists(imagePath1))
        {
            byte[] fileData = File.ReadAllBytes(imagePath1);
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
            Debug.LogWarning("Файл не найден по указанному пути: " + imagePath1);
        }
    }


    Sprite SpriteFromTexture(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                             new Vector2(0.5f, 0.5f));
    }
}
