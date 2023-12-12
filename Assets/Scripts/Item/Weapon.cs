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
            //TODO �÷��̾� ���� ����
            isEquip = false;
        }
        else
        {
            //TODO �÷��̾� ���� �ø�
            isEquip = true;
        }
        return isEquip;
    }
}
