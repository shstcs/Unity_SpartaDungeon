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
        ItemName,
        ItemDescription,
        EquipText
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
            Debug.Log(Managers.ItemManager.currentItem.Name);
            GetText((int)Texts.ItemName).text = Managers.ItemManager.currentItem.Name;
            GetImage((int)Images.ItemImage).sprite = Resources.Load<Sprite>("Images\\Items\\" + Managers.ItemManager.currentItem.Name);
            GetText((int)Texts.ItemDescription).text = Managers.ItemManager.currentItem.Description;
            GetText((int)Texts.EquipText).text = Managers.ItemManager.currentItem.IsEquip ? "UnEquip" : "Equip";
        }
        else Debug.Log("currentItem is null");
    }

    private void Equip(PointerEventData data)
    {
        Debug.Log($"장착 전 공격력 : {Managers.Player.Atk}, 방어력 : {Managers.Player.Def}");
        Managers.ItemManager.GetItem(Managers.ItemManager.currentItem).Equip();
        Debug.Log($"장착 후 공격력 : {Managers.Player.Atk}, 방어력 : {Managers.Player.Def}");
        Managers.UI.ClosePopupUI(this);
    }

    private void CancelEquip(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
    }
}
