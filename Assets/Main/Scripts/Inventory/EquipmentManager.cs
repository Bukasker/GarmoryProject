using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    private VisualElement root;
    private Dictionary<ItemCategory, EquipmentSlot> equipmentSlots = new Dictionary<ItemCategory, EquipmentSlot>();

    public Sprite commonBG;
    public Sprite uncommonBG;
    public Sprite rareBG;
    public Sprite epicBG;
    public Sprite legendaryBG;

    public SpriteRenderer weaponHolder;

    public delegate void OnEquipmentChanged(Item newItem, Item oldItem);
    public event OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        InitializeEquipmentSlots();
    }

    private void InitializeEquipmentSlots()
    {
        equipmentSlots.Clear();

        AddEquipmentSlot(ItemCategory.Helmet, "HelmetSlot");
        AddEquipmentSlot(ItemCategory.Armor, "ArmorSlot");
        AddEquipmentSlot(ItemCategory.Boots, "BootsSlot");
        AddEquipmentSlot(ItemCategory.Weapon, "WeaponSlot");
        AddEquipmentSlot(ItemCategory.Necklace, "NecklaceSlot");
        AddEquipmentSlot(ItemCategory.Ring, "RingSlot");
    }

    private void AddEquipmentSlot(ItemCategory category, string uiElementName)
    {
        VisualElement slotElement = root.Q<VisualElement>(uiElementName);
        if (slotElement != null)
        {
            EquipmentSlot newSlot = new EquipmentSlot(category, slotElement, commonBG, uncommonBG, rareBG, epicBG, legendaryBG);
            equipmentSlots[category] = newSlot;
        }
    }

    public void Equip(Item item)
    {
        if (!equipmentSlots.TryGetValue(item.Category, out EquipmentSlot slot))
        {
            return;
        }

        Item oldItem = slot.SlotItem;
        slot.AddItemToSlot(item);

        Inventory.Instance.RemoveItem(item);

        if (oldItem != null)
        {
            Inventory.Instance.AddItem(oldItem);
        }

        onEquipmentChanged?.Invoke(item, oldItem);

        if (item.Category == ItemCategory.Weapon)
        {
            UpdateWeaponSprite(item.ItemIcon);
        }
    }

    public void Unequip(ItemCategory category, Item item)
    {
        if (!equipmentSlots.TryGetValue(category, out EquipmentSlot slot) || slot.SlotItem == null)
        {
            return;
        }

        Inventory.Instance.AddItem(slot.SlotItem);
        slot.ClearSlot();

        onEquipmentChanged?.Invoke(null, item);

        if (category == ItemCategory.Weapon)
        {
            UpdateWeaponSprite(null);
        }
    }

    private void UpdateWeaponSprite(Sprite newSprite)
    {
        if (weaponHolder != null)
        {
            weaponHolder.sprite = newSprite;
        }
    }
}
