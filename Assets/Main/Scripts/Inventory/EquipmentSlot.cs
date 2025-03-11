using UnityEngine;
using UnityEngine.UIElements;

public class EquipmentSlot : InventorySlot
{
    public ItemCategory Category { get; private set; }

    public EquipmentSlot(ItemCategory category, VisualElement slot, Sprite common, Sprite uncommon, Sprite rare, Sprite epic, Sprite legendary)
        : base(slot, common, uncommon, rare, epic, legendary)
    {
        Category = category;
    }

    protected override void UseItem()
    {
        if (SlotItem != null)
        {
            EquipmentManager.Instance.Unequip(Category, SlotItem);
        }
    }
}
