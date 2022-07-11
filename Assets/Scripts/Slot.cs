using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;

    public int index;

    public void SetImage(Item item)
    {
        transform.gameObject.GetComponent<Image>().sprite = item.getSprite(item);
    }
}