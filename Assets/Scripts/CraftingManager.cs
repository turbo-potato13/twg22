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
    public GameObject garden;
    public TaskManager taskManager;

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
                firstPerson.takeItem(slot.item);
                firstPerson.activateGun();
            }

            if ((int) slot.item.itemType == 10)
            {
                firstPerson.takeItem(slot.item);
                garden.SetActive(true);
            }
            checkTask(slot.item);
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

    public void checkTask(Item item)
    {
        int count = 0;
        firstPerson.inventory.TryGetValue(item.itemType, out count);
        if (item.itemType == Item.ItemType.Gun && count > 0)
        {
            enableSuccessTask(0);
            taskManager.enableAllTasks();
        }

        if (item.itemType == Item.ItemType.Filter && count >= 5)
        {
            enableSuccessTask(1);
        }

        if (item.itemType == Item.ItemType.SunPanel && count >= 4)
        {
            enableSuccessTask(2);
        }

        if (item.itemType == Item.ItemType.Garden && count > 0)
        {
            enableSuccessTask(3);
        }
        
    }

    private void enableSuccessTask(int taskNumber)
    {
        taskManager.successTask(taskNumber);
        firstPerson.TaskText.gameObject.SetActive(true);
        firstPerson.TaskText.text = "Вы выполнили задание";
        Invoke("disableText", 2);
    }
    private void disableText()
    {
        firstPerson.TaskText.gameObject.SetActive(false);
    }
}