using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public Armor(string _name, int _plusStat) : base(_name, _plusStat)
    {
    }

    public override void Equip()
    {
        if (IsEquip)
        {
            //TODO �÷��̾� ���� ����
            Debug.Log($"{name} ���� �����մϴ�");
            SetEquip(false);
        }
        else
        {
            //TODO �÷��̾� ���� �ø�
            Debug.Log($"{name} �����մϴ�");
            SetEquip(true);
        }
    }
}
