using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;


public class ServerItemJsonReader : MonoBehaviour
{
    private GameServerMock gameServerMock;

    [SerializeField] private Sprite[] allIcons;

    private async void Start()
    {
        gameServerMock = new GameServerMock();
        await FetchAndCreateItem();
    }

    private async Task FetchAndCreateItem()
    {
        string jsonData = await gameServerMock.GetItemsAsync();
        JObject root = JObject.Parse(jsonData);
        JArray itemsArray = (JArray)root["Items"];

        foreach (JObject itemData in itemsArray)
        {
            CreateItemFromJson(itemData);
        }
    }

    private void CreateItemFromJson(JObject itemData)
    {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.Name = itemData["Name"].ToString();
        newItem.Category = (ItemCategory)System.Enum.Parse(typeof(ItemCategory), itemData["Category"].ToString());
        newItem.Rarity = itemData["Rarity"].ToObject<int>();
        newItem.Damage = itemData["Damage"].ToObject<int>();
        newItem.HealthPoints = itemData["HealthPoints"].ToObject<int>();
        newItem.Defense = itemData["Defense"].ToObject<int>();
        newItem.LifeSteal = itemData["LifeSteal"].ToObject<float>();
        newItem.CriticalStrikeChance = itemData["CriticalStrikeChance"].ToObject<float>();
        newItem.AttackSpeed = itemData["AttackSpeed"].ToObject<float>();
        newItem.MovementSpeed = itemData["MovementSpeed"].ToObject<float>();
        newItem.Luck = itemData["Luck"].ToObject<float>();

        if (allIcons.Length > 0)
        {
            newItem.ItemIcon = FindIconByName(newItem.Name) ?? allIcons[0];
        }

        Inventory.Instance.AddItem(newItem);
    }

    private Sprite FindIconByName(string itemName)
    {
        foreach (Sprite icon in allIcons)
        {
            if (icon.name == itemName)
            {
                return icon;
            }
        }
        return null;
    }
}
