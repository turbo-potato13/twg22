using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;

    public Slot[] craftingSlots;

    public List<Item> itemList;
    public List<int> recipes;
    public Item[] recipeResults;
    public Slot resultSlot;

    public FirstPersonDog firstPerson;

    private void Awake()
    {
        if (firstPerson == null)
        {
            firstPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (currentItem != null)
            {
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;
                foreach (Slot slot in craftingSlots)
                {
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if (dist < shortestDistance)
                    {
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }

                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.getSprite(currentItem);
                nearestSlot.item = currentItem;
                itemList[nearestSlot.index] = currentItem;

                currentItem = null;
                CheckForCreatedRecipes();
            }
        }
    }

    public void OnMouseDownItem(Item item)
    {
        if (firstPerson.tryGetItem(item))
        {
            if (currentItem == null)
            {
                currentItem = item;
                customCursor.gameObject.SetActive(true);
                customCursor.sprite = currentItem.getSprite(item);
            }
        }
    }

    public void CheckForCreatedRecipes()
    {
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;
        int currentRecipe = 0;

        foreach (Item item in itemList)
        {
            if (item != null)
            {
                currentRecipe += (int) item.itemType;
            }
            else
            {
                currentRecipe += 42;
            }
        }

        currentRecipe *= 10;

        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i] == currentRecipe)
            {
                resultSlot.gameObject.SetActive(true);
                resultSlot.SetImage(recipeResults[i]);
                resultSlot.item = recipeResults[i];
            }
        }
    }

    public void OnClickSlot(Slot slot)
    {
        slot.item = null;
        itemList[slot.index] = null;
        slot.gameObject.SetActive(false);
        CheckForCreatedRecipes();
    }

    public void OnClickResultSlot(Slot slot)
    {
        if (slot.item != null)
        {
            if ((int) slot.item.itemType < 9)
            {
                firstPerson.takeItem(slot.item);
            }

            if ((int) slot.item.itemType == 12)
            {
                firstPerson.activateGun();
            }

            OnClickSlot(slot);
            refreshSlots();
        }
    }

    public void refreshSlots()
    {
        foreach (Item item in itemList)
        {
            if (item != null)
            {
                firstPerson.removeItem(item);
            }
        }

        foreach (Slot slot in craftingSlots)
        {
            OnClickSlot(slot);
        }
    }
}