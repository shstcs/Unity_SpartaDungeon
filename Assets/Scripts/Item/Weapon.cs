using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Weapon(string _name, int _plusStat, string _description) : base(_name, _plusStat, _description)
    {
    }

    public override void Equip()
    {
        if(IsEquip)
        {
            Managers.Player.Atk -= plusStat;
            SetEquip(false);
        }
        else
        {
            Managers.Player.Atk += plusStat;
            SetEquip(true);
        }
    }
}
