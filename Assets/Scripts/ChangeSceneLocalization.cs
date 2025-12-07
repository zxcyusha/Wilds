using Lessons.Plugins.Lesson_Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneLocalization : MonoBehaviour
{
    public Material MainInstrucsia;
    public Material Instrucsia1;
    public Material Instrucsia2;

    public Texture Main1Ru;
    public Texture Main2Ru;
    public Texture Main3Ru;
    public Texture Main4Ru;
    public Texture Main5Ru;
    public Texture Main1Engl;
    public Texture Main2Engl;
    public Texture Main3Engl;
    public Texture Main4Engl;
    public Texture Main5Engl;

    public Texture Instr1Ru;
    public Texture Instr1Engl;

    public Texture Instr2Ru;
    public Texture Instr2Engl;

    public Image list;
    public Texture2D listRu;
    public Texture2D listEngl;

    private void Start()
    {
        Time.timeScale = 1f;
        Change();
    }
    public void Change()
    {
        if (LanguageManager.Language.ToString() == "Russian")
        {
            Instrucsia1.SetTexture("_MainTex", Instr1Ru);
            Instrucsia2.SetTexture("_MainTex", Instr2Ru);

            Sprite listRussia = SpriteFromTexture(listRu);
            list.sprite = listRussia;

            if (DAYS.DAY1) MainInstrucsia.SetTexture("_MainTex", Main1Ru);
            if (DAYS.DAY2) MainInstrucsia.SetTexture("_MainTex", Main2Ru);
            if (DAYS.DAY3) MainInstrucsia.SetTexture("_MainTex", Main4Ru);
            if (DAYS.DAY4) MainInstrucsia.SetTexture("_MainTex", Main4Ru);
            if (DAYS.DAY5) MainInstrucsia.SetTexture("_MainTex", Main5Ru);
        }
        else
        {
            Instrucsia1.SetTexture("_MainTex", Instr1Engl);
            Instrucsia2.SetTexture("_MainTex", Instr2Engl);

            Sprite listEnglish = SpriteFromTexture(listEngl);
            list.sprite = listEnglish;


            if (DAYS.DAY1) MainInstrucsia.SetTexture("_MainTex", Main1Engl);
            if (DAYS.DAY2) MainInstrucsia.SetTexture("_MainTex", Main2Engl);
            if (DAYS.DAY3) MainInstrucsia.SetTexture("_MainTex", Main3Engl);
            if (DAYS.DAY4) MainInstrucsia.SetTexture("_MainTex", Main4Engl);
            if (DAYS.DAY5) MainInstrucsia.SetTexture("_MainTex", Main5Engl);
        }
    }

    public void DropChange(int index)
    {
        Change();
    }

    Sprite SpriteFromTexture(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                             new Vector2(0.5f, 0.5f));
    }
}
