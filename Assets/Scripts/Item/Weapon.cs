using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private bool isEquip = false;
    private int plusStat;

    public Weapon(string _name, int _plusStat) : base(_name, _plusStat)
    {
    }

    public bool Equip()
    {
        if(isEquip)
        {
            //TODO 플레이어 스탯 내림
            isEquip = false;
        }
        else
        {
            //TODO 플레이어 스탯 올림
            isEquip = true;
        }
        return isEquip;
    }
}
