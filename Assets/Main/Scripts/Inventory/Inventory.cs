    using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item> AllItems = new List<Item>();
    private List<Item> ArrmorItems = new List<Item>();
    private List<Item> BootsItems = new List<Item>();
    private List<Item> HelmetItems = new List<Item>();
    private List<Item> NecklaceItems = new List<Item>();
    private List<Item> RingItems = new List<Item>();
    private List<Item> WeaponItems = new List<Item>();

    private List<Item> ChosenListOfItems = new List<Item>();

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public static Inventory Instance;

    #region Singeton
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Error : More than one instance of Inventory found");
            return;
        }
        Instance = this;
    }
    #endregion

    public void AddItem(Item item)
    {
        if (item != null)
        {
            AllItems.Add(item);
            ChooseItemList(item);
            Item copyItem = Instantiate(item);
            ChosenListOfItems.Add(copyItem);
            onItemChangedCallback.Invoke();
        }
    }
    public void RemoveItem(Item item)
    {
        AllItems.Remove(item);
        ChooseItemList(item);
        ChosenListOfItems.Remove(item);
        onItemChangedCallback.Invoke();
    }
    public void ChooseItemList(Item item)
    {
        switch (item.Category)
        {
            case ItemCategory.Armor:
                ChosenListOfItems = ArrmorItems;
                break;
            case ItemCategory.Boots:
                ChosenListOfItems = BootsItems;
                break;
            case ItemCategory.Helmet:
                ChosenListOfItems = HelmetItems;
                break;
            case ItemCategory.Necklace:
                ChosenListOfItems = NecklaceItems;
                break;
            case ItemCategory.Ring:
                ChosenListOfItems = RingItems;
                break;
            case ItemCategory.Weapon:
                ChosenListOfItems = WeaponItems;
                break;
        }
    }
}
