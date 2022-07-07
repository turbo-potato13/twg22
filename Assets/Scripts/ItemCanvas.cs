using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCanvas : MonoBehaviour
{
    public TMP_Text metalCountText;
    public TMP_Text coalCountText;

    public void setCount(Dictionary<String, int> items)
    {
        int metalCount = 0;
        items.TryGetValue("металл", out metalCount);
        metalCountText.text = "Металл: " + metalCount + " шт.";

        int coalCount = 0;
        items.TryGetValue("уголь", out coalCount);
        coalCountText.text = "Уголь: " + coalCount + " шт.";
    }
}