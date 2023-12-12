using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven : UI_PopUp
{

    enum Buttons
    {
        BackButton
    }
    enum Images
    {
        Character,
        Inven,
        Item,
        Border1,
        Bag
    }


    private void Start()
    {
        Init();
        Managers.ItemManager.ItemEquiped += CheckEquipment;
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.BackButton).gameObject.BindEvent(ShowTitle);
        GetImage((int)Images.Item).gameObject.BindEvent(ShowEquip);

        CheckEquipment();
        
    }

    private void ShowEquip(PointerEventData data)
    {
        string choiceItemName = GetImage((int)Images.Bag).name;
        if (choiceItemName != null)
        {
            Managers.ItemManager.SelectItem(choiceItemName);
            Debug.Log(Managers.ItemManager.GetItem(Managers.ItemManager.currentItem).IsEquip);
        }
        Managers.UI.ShowPopupUI<UI_Equip>("EquipCanvas");
    }

    private void ShowTitle(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_Title>("TitleCanvas");
    }

    private void CheckEquipment()
    {
        //가져온 이미지의 이름을 가진 아이템이 장착되어 있는지 확인
        if (Managers.ItemManager.GetItem(GetImage((int)Images.Bag).name).IsEquip)
        {
            GetImage((int)Images.Border1).gameObject.SetActive(true);
        }
        else
        {
            GetImage((int)Images.Border1).gameObject.SetActive(false);
        }
    }
}
