using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public Armor(string _name, int _plusStat, string _description) : base(_name, _plusStat,_description)
    {

    }

    public override void Equip()
    {
        if (IsEquip)
        {
            //TODO 플레이어 스탯 내림
            Managers.Player.Def -= plusStat;
            Debug.Log($"{name} 장착 해제합니다");
            SetEquip(false);
        }
        else
        {
            //TODO 플레이어 스탯 올림
            Managers.Player.Def += plusStat;
            Debug.Log($"{name} 장착합니다");
            SetEquip(true);
        }
    }
}
