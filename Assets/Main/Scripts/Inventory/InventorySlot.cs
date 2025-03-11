using UnityEngine;
using UnityEngine.UIElements;

public class InventorySlot
{
    public Item SlotItem = null;

    protected VisualElement slot;
    protected Button icon;
    protected VisualElement background;

    private Sprite commonBG;
    private Sprite uncommonBG;
    private Sprite rareBG;
    private Sprite epicBG;
    private Sprite legendaryBG;

    public InventorySlot(VisualElement slot, Sprite common, Sprite uncommon, Sprite rare, Sprite epic, Sprite legendary)
    {
        this.slot = slot;
        commonBG = common;
        uncommonBG = uncommon;
        rareBG = rare;
        epicBG = epic;
        legendaryBG = legendary;

        background = new VisualElement();
        background.AddToClassList("slot-background");
        slot.Add(background);

        icon = new Button();
        icon.AddToClassList("slot-icon");
        slot.Add(icon);

        icon.clicked += () => UseItem();
    }

    protected virtual void UseItem()
    {
        if (SlotItem != null)
        {
            EquipmentManager.Instance.Equip(SlotItem);
        }
    }

    public void AddItemToSlot(Item item)
    {
        SlotItem = item;
        icon.style.backgroundImage = new StyleBackground(item.ItemIcon);
        icon.style.display = DisplayStyle.Flex;

        switch (item.Rarity)
        {
            case 0:
                background.style.backgroundImage = new StyleBackground(commonBG);
                break;
            case 1:
                background.style.backgroundImage = new StyleBackground(uncommonBG);
                break;
            case 2:
                background.style.backgroundImage = new StyleBackground(rareBG);
                break;
            case 3:
                background.style.backgroundImage = new StyleBackground(epicBG);
                break;
            case 4:
                background.style.backgroundImage = new StyleBackground(legendaryBG);
                break;
        }
    }

    public void ClearSlot()
    {
        SlotItem = null;
        icon.style.display = DisplayStyle.None;
        background.style.backgroundImage = new StyleBackground(commonBG);
    }
}
