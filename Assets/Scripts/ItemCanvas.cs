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

    public void setCount(Dictionary<Item.ItemType, int> items)
    {
        int metalCount = 0;
        items.TryGetValue(Item.ItemType.Metal, out metalCount);
        metalCountText.text = "Металл: " + metalCount + " шт.";

        int coalCount = 0;
        items.TryGetValue(Item.ItemType.Coal, out coalCount);
        coalCountText.text = "Уголь: " + coalCount + " шт.";

        int soilCount = 0;
        items.TryGetValue(Item.ItemType.Soil, out soilCount);
        soilCountText.text = "Почва: " + soilCount + " шт.";

        int waterCount = 0;
        items.TryGetValue(Item.ItemType.Water, out waterCount);
        waterCountText.text = "Вода: " + waterCount + " шт.";

        int semenCount = 0;
        items.TryGetValue(Item.ItemType.Semen, out semenCount);
        semenCountText.text = "Семена: " + semenCount + " шт.";

        int filterCount = 0;
        items.TryGetValue(Item.ItemType.Filter, out filterCount);
        filterCountText.text = "Фильтр: " + filterCount + " шт.";

        int sunPanelBrokenCount = 0;
        items.TryGetValue(Item.ItemType.SunPanelBroke, out sunPanelBrokenCount);
        sunPanelBrokenCountText.text = "Солнечные\n панели(слом):\n" + sunPanelBrokenCount + " шт.";

        int sunPanelCount = 0;
        items.TryGetValue(Item.ItemType.SunPanel, out sunPanelCount);
        sunPanelCountText.text = "Солнечные\n панели:\n" + sunPanelCount + " шт.";
    }
}