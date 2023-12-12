using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Title : UI_PopUp
{
    enum Buttons
    {
        Status,
        Inventory
    }
    enum GameObjects
    {
        StatusSelected,
        InvenSelected
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        GetButton((int)Buttons.Status).gameObject.BindEvent(ShowStatus);
        GetButton((int)Buttons.Inventory).gameObject.BindEvent(ShowInventory);
        GetObject((int)GameObjects.InvenSelected).SetActive(false);
        GetObject((int)GameObjects.StatusSelected).SetActive(false);
        
    }

    private void ShowStatus(PointerEventData data)
    {
        //스테이터스 창 생성
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_Status>("StatusCanvas");
    }

    private void ShowInventory(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_Inven>("InvenCanvas");
    }
}
