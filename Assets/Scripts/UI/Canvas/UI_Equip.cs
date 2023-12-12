using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Equip : UI_PopUp
{
    enum Buttons
    {
        EquipButton,
        CancelButton
    }
    enum Images
    {
        Background,
        ItemImage
           
    }
    enum Texts
    {
        ItemName
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<TMP_Text>(typeof(Texts));

        GetButton((int)Buttons.EquipButton).gameObject.BindEvent(Equip);
        GetButton((int)Buttons.CancelButton).gameObject.BindEvent(CancelEquip);
        if (Managers.ItemManager.currentItem != null)
        {
            Debug.Log(GetText((int)Texts.ItemName).text);
            GetText((int)Texts.ItemName).text = Managers.ItemManager.GetItem(Managers.ItemManager.currentItem).Name;
        }
        else Debug.Log("currentItem is null");
    }

    private void Equip(PointerEventData data)
    {
        Managers.ItemManager.GetItem(Managers.ItemManager.currentItem).Equip();
        Managers.ItemManager.ClearCurrentItem();
        Managers.UI.ClosePopupUI(this);
    }

    private void CancelEquip(PointerEventData data)
    {
        Managers.ItemManager.ClearCurrentItem();
        Managers.UI.ClosePopupUI(this);
    }
}
