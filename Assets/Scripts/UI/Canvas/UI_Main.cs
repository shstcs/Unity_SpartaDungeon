using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class UI_Main : UI_Scene
{
    enum Texts
    {
        Title,
        GoldText
    }

    enum Images
    {
        Background,
        GoldImage
    }

    enum GameObjects
    {
        Gold
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init(); // UI_Button 의 부모인 UI_PopUp 의 Init() 호출

        Bind<TMP_Text>(typeof(Texts));  // 텍스트 오브젝트들 가져와 dictionary인 _objects에 바인딩. 
        Bind<GameObject>(typeof(GameObjects));  // 빈 오브젝트들 가져와 dictionary인 _objects에 바인딩. 
        Bind<Image>(typeof(Images));  // 이미지 오브젝트들 가져와 dictionary인 _objects에 바인딩. 

        // 이미지(go)에 UI_EventHandler를 붙이고 파라미터로 넘긴 람다 함수를 OnDragHandler 액션에 등록한다.
        GameObject go = GetImage((int)Images.Background).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

    }

}
