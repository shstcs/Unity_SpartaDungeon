using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        ShowTitle();
        Managers.ItemManager.AddItem("Bag", new Armor("»Á«— ∞°πÊ", 5));
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
