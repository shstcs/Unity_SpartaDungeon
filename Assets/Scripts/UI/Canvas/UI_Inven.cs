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
        Inven,
        Border1,
        Border2,
        Border3,
        Border4,
        Border5,
        Border6,
        Border7,
        Border8,
        Border9,
        Border10,
        Border11,
        Border12,
        Item1,
        Item2,
        Item3,
        Item4,
        Item5,
        Item6,
        Item7,
        Item8,
        Item9,
        Item10,
        Item11,
        Item12,
        Character
    }
    private Item[] items;
    private int InvenLength = 12;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        CheckEquipment();
    }

    public override void Init()
    {
        base.Init();
        Managers.ItemManager.ItemEquiped -= CheckEquipment;
        Managers.ItemManager.ItemEquiped += CheckEquipment;

        items = Managers.Player.ShowInven();

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.BackButton).gameObject.BindEvent(ShowTitle);

        for (int i = 0; i < items.Length; i++)
        {
            //GetImage((int)Images.Item1 + i).gameObject.BindEvent((PointerEventData data) => Managers.ItemManager.SelectItem(items[i]));
            GetImage((int)Images.Item1 + i).gameObject.BindEvent(ShowEquip);
        }
        SetItems();
    }

    private void ShowEquip(PointerEventData data)
    {
        string clickObjectName = data.pointerCurrentRaycast.gameObject.name;
        int clickItemNumber = int.Parse(clickObjectName.Substring(clickObjectName.Length - 1)) - 1;
        Item choiceItemName = items[clickItemNumber];
        if (choiceItemName != null)
        {
            Managers.ItemManager.SelectItem(choiceItemName);
        }
        else Debug.Log("item is null");

        Managers.UI.ShowPopupUI<UI_Equip>("EquipCanvas");
    }

    private void ShowTitle(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_Title>("TitleCanvas");
    }

    private void SetItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            GetImage((int)Images.Item1 + i).sprite = Resources.Load<Sprite>("Images\\Items\\" + items[i].Name);
            GetImage((int)Images.Item1 + i).color = new Color(1, 1, 1, 1);
        }
        for(int i = items.Length; i < InvenLength; i++)
        {
            GetImage((int)Images.Item1 + i).color = new Color(1, 1, 1, 0);
        }
    }

    private void CheckEquipment()
    {
        for (int i = 0; i < items.Length; i++)
        {
            //가져온 이미지의 이름을 가진 아이템이 장착되어 있는지 확인
            if (Managers.ItemManager.CheckEquip(items[i].Name))
            {
                GetImage((int)Images.Border1 + i).gameObject.SetActive(true);
            }
            else
            {
                GetImage((int)Images.Border1 + i).gameObject.SetActive(false);
            }
        }
        for(int i = items.Length; i < InvenLength; i++)
        {
            GetImage((int)Images.Border1 + i).gameObject.SetActive(false);
        }

    }
}
