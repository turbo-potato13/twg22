using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public Sprite metalSprite;
    public Sprite coalSprite;
    public Sprite soilSprite;
    public Sprite waterSprite;
    public Sprite semenSprite;
    public Sprite filterSprite;
    public Sprite sunPanelBrokenSprite;
    public Sprite sunPanelSprite;
}