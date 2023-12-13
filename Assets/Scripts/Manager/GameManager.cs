using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        ShowTitle();

        //아이템매니저에 아이템 등록
        Managers.ItemManager.AddItem("Bow", new Weapon("Bow", 5,"좋은 활이다."));
        Managers.ItemManager.AddItem("Hammer", new Weapon("Hammer", 10, "좋은 해머다."));
        Managers.ItemManager.AddItem("Iron Sword", new Weapon("Iron Sword", 15, "좋은 칼이다."));
        Managers.ItemManager.AddItem("Iron Armor", new Armor("Iron Armor", 15, "좋은 갑옷이다."));
        Managers.ItemManager.AddItem("Iron Boot", new Armor("Iron Boot", 10, "좋은 부츠다."));
        Managers.ItemManager.AddItem("Iron Helmet", new Armor("Iron Helmet", 5, "좋은 투구다."));

        //플레이어에게도 아이템 지급
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Sword"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Helmet"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Bow"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Hammer"));
        Managers.Player.AddItem(Managers.ItemManager.GetItem("Iron Armor"));

        Debug.Log($"현재 가지고 있는 아이템 {Managers.Player.ShowInven().Length}개");
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
