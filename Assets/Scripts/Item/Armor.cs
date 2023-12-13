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
            //TODO �÷��̾� ���� ����
            Managers.Player.Def -= plusStat;
            Debug.Log($"{name} ���� �����մϴ�");
            SetEquip(false);
        }
        else
        {
            //TODO �÷��̾� ���� �ø�
            Managers.Player.Def += plusStat;
            Debug.Log($"{name} �����մϴ�");
            SetEquip(true);
        }
    }
}
