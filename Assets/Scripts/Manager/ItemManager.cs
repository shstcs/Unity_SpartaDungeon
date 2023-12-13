using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Dictionary<string, Item> items = new Dictionary<string, Item>();
    public Item currentItem { get; private set; }
    public event Action ItemEquiped;
    public void AddItem(string name, Item item)
    {
        if (item == null) return;
        items[name] = item;
    }
    public Item GetItem(string name)
    {
        if (items.ContainsKey(name)) return items[name];
        else return null;
    }

    public Item GetItem(Item item)
    {
        if (items.ContainsKey(item.Name)) return items[item.Name];
        else return null;
    }

    public void SelectItem(Item item)
    {
        if (item == null) return;
        currentItem = item;
    }

    public void ClearCurrentItem()
    {
        ItemEquiped?.Invoke();
        currentItem = null;
    }

    public bool CheckEquip(string itemName)
    {
        return items[itemName].IsEquip;
    }

}
