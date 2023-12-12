using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Dictionary<string, Item> items = new Dictionary<string, Item>();
    public string currentItem { get; private set; }
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

    public void SelectItem(string itemName)
    {
        if (itemName == null) return;
        currentItem = itemName;
    }

    public void ClearCurrentItem()
    {
        ItemEquiped?.Invoke();
        currentItem = null;
    }
}
