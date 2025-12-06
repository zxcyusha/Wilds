using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedSlotsView : MonoBehaviour
{
    public Image[] slots;
    public Button[] buttons;

    //public void ChangeSlot(int index, Sprite screenshot)
    //{
    //    slots[index].sprite = screenshot;
    //}
    public void ChangeSlot(int index, Color color)
    {
        slots[index].color = color;
    }



}
