using System;
using TMPro;
using UnityEngine;

[Serializable]
public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Metal = 1,
        Coal = 2,
        Soil = 3,
        Water = 4,
        Semen = 5,
        Filter = 6,
        SunPanel = 7,
        SunPanelBroke = 8,
        Light = 9,
        Garden = 10
    }

    public ItemType itemType;
    public int amount;
    public TMP_Text textTMP;

    public Sprite getSprite(Item currentItem)
    {
        var currentItemType = currentItem.itemType;
        switch (currentItemType)
        {
            case ItemType.Metal: return ItemAssets.instance.metalSprite;
            case ItemType.Coal: return ItemAssets.instance.coalSprite;
            case ItemType.Soil: return ItemAssets.instance.soilSprite;
            case ItemType.Water: return ItemAssets.instance.waterSprite;
            case ItemType.Semen: return ItemAssets.instance.semenSprite;
            case ItemType.Filter: return ItemAssets.instance.filterSprite;
            case ItemType.SunPanel: return ItemAssets.instance.sunPanelSprite;
            case ItemType.SunPanelBroke: return ItemAssets.instance.sunPanelBrokenSprite;
        }

        return null;
    }
}