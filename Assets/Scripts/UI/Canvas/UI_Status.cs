using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Status : UI_PopUp
{
    enum Buttons
    {
        BackButton
    }
    enum Images
    {
        Character,
        CharacterPanel,
        StatPanel
    }
    enum Texts
    {
        IDText,
        LevelText,
        atkValue,
        defValue,
        HPValue,
        criValue
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

        GetText((int)Texts.IDText).text = Managers.Player.UserName;
        GetText((int)Texts.LevelText).text = Managers.Player.Level.ToString();
        GetText((int)Texts.atkValue).text = Managers.Player.Atk.ToString();
        GetText((int)Texts.defValue).text = Managers.Player.Def.ToString();
        GetText((int)Texts.HPValue).text = Managers.Player.HP.ToString();
        GetText((int)Texts.criValue).text = Managers.Player.Critical.ToString();
        GetButton((int)Buttons.BackButton).gameObject.BindEvent(ShowTitle);
    }

    private void ShowTitle(PointerEventData data)
    {
        Managers.UI.ClosePopupUI(this);
        Managers.UI.ShowPopupUI<UI_Title>("TitleCanvas");
    }
}
