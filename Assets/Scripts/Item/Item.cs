using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected readonly string name;
    public string Name { get { return name; } }
    protected readonly int plusStat;
    protected readonly string description;
    public string Description { get { return description; } }
    private bool isEquip = false;
    public bool IsEquip
    {
        get
        {
            return isEquip;
        }
    }

    public void SetEquip(bool Equip)
    {
        isEquip = Equip;
    }
    public Item(string _name, int _plusStat, string _description)
    {
        name = _name;
        plusStat = _plusStat;
        description = _description;
    }
    public virtual void Equip() { }
}
