using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    private VisualElement root;
    private ScrollView slotListScrollView;
    private VisualElement slotContainer;

    public Sprite commonBG;
    public Sprite uncommonBG;
    public Sprite rareBG;
    public Sprite epicBG;
    public Sprite legendaryBG;

    private List<InventorySlot> slots = new List<InventorySlot>();
    private string currentCategory = "All";

    private void Start()
    {
        Inventory.Instance.onItemChangedCallback += UpdateInventoryUI;
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        slotListScrollView = root.Q<ScrollView>("SlotListScrollView");
        slotContainer = root.Q<VisualElement>("SlotContainer");

        root.Q<Button>("CategoryAll").clicked += () => FilterInventory("All");
        root.Q<Button>("CategoryArmor").clicked += () => FilterInventory("Armor");
        root.Q<Button>("CategoryBoots").clicked += () => FilterInventory("Boots");
        root.Q<Button>("CategoryHelmet").clicked += () => FilterInventory("Helmet");
        root.Q<Button>("CategoryNecklace").clicked += () => FilterInventory("Necklace");
        root.Q<Button>("CategoryRing").clicked += () => FilterInventory("Ring");
        root.Q<Button>("CategoryWeapon").clicked += () => FilterInventory("Weapon");

        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        List<Item> filteredItems = Inventory.Instance.AllItems.FindAll(item => currentCategory == "All" || item.Category.ToString() == currentCategory);
        int itemCount = filteredItems.Count;

        while (slots.Count < itemCount)
        {
            VisualElement newSlotElement = new VisualElement();
            newSlotElement.AddToClassList("slot");
            slotContainer.Add(newSlotElement);

            InventorySlot newSlot = new InventorySlot(newSlotElement, commonBG, uncommonBG, rareBG, epicBG, legendaryBG);
            slots.Add(newSlot);
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < itemCount)
            {
                slots[i].AddItemToSlot(filteredItems[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    private void FilterInventory(string category)
    {
        currentCategory = category;
        UpdateInventoryUI();
    }
}
