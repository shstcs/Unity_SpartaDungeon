using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected readonly string name;
    public string Name { get { return name; } }
    protected readonly int plusStat;
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
    public Item(string _name, int _plusStat)
    {
        name = _name;
        plusStat = _plusStat;
    }
    public virtual void Equip() { }
}
