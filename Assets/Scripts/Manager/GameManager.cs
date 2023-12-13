using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        ShowTitle();

        //�����۸Ŵ����� ������ ���
        Managers.ItemManager.AddItem("Bow", new Weapon("Bow", 5,"���� Ȱ�̴�."));
        Managers.ItemManager.AddItem("Hammer", new Weapon("Hammer", 10, "���� �ظӴ�."));
        Managers.ItemManager.AddItem("Iron Sword", new Weapon("Iron Sword", 15, "���� Į�̴�."));
        Managers.ItemManager.AddItem("Iron Armor", new Armor("Iron Armor", 15, "���� �����̴�."));
        Managers.ItemManager.AddItem("Iron Boot", new Armor("Iron Boot", 10, "���� ������."));
        Managers.ItemManager.AddItem("Iron Helmet", new Armor("Iron Helmet", 5, "���� ������."));

        //�÷��̾�Ե� ������ ����
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Sword"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Helmet"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Bow"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Hammer"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Armor"));

        Debug.Log($"���� ������ �ִ� ������ {Managers.Player.ShowInven().Length}��");
    }


    void Update()
    {
        
    }

    private void ShowTitle()
    {
        Managers.UI.ShowSceneUI<UI_Main>("MainCanvas");
        Managers.UI.ShowPopupUI<UI_Title>("TitleCanvas");
    }
}
