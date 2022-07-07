using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCanvas : MonoBehaviour
{
    public TMP_Text metalCountText;
    public TMP_Text coalCountText;
    public TMP_Text soilCountText;
    public TMP_Text waterCountText;
    public TMP_Text semenCountText;
    public TMP_Text filterCountText;
    public TMP_Text sunPanelBrokenCountText;
    public TMP_Text sunPanelCountText;

    public void setCount(Dictionary<String, int> items)
    {
        int metalCount = 0;
        items.TryGetValue("металл", out metalCount);
        metalCountText.text = "Металл: " + metalCount + " шт.";

        int coalCount = 0;
        items.TryGetValue("уголь", out coalCount);
        coalCountText.text = "Уголь: " + coalCount + " шт.";

        int soilCount = 0;
        items.TryGetValue("почва", out soilCount);
        soilCountText.text = "Почва: " + soilCount + " шт.";

        int waterCount = 0;
        items.TryGetValue("вода", out waterCount);
        waterCountText.text = "Вода: " + waterCount + " шт.";

        int semenCount = 0;
        items.TryGetValue("семена", out semenCount);
        semenCountText.text = "Семена: " + semenCount + " шт.";

        int filterCount = 0;
        items.TryGetValue("фильтр", out filterCount);
        filterCountText.text = "Фильтр: " + filterCount + " шт.";

        int sunPanelBrokenCount = 0;
        items.TryGetValue("солнечныеХ", out sunPanelBrokenCount);
        sunPanelBrokenCountText.text = "Солнечные\n батареи (слом): " + sunPanelBrokenCount + " шт.";

        int sunPanelCount = 0;
        items.TryGetValue("солнечные", out sunPanelCount);
        sunPanelCountText.text = "Солнечные батареи: " + sunPanelCount + " шт.";
    }
}