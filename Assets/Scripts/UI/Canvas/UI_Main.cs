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
        base.Init(); // UI_Button �� �θ��� UI_PopUp �� Init() ȣ��

        Bind<TMP_Text>(typeof(Texts));  // �ؽ�Ʈ ������Ʈ�� ������ dictionary�� _objects�� ���ε�. 
        Bind<GameObject>(typeof(GameObjects));  // �� ������Ʈ�� ������ dictionary�� _objects�� ���ε�. 
        Bind<Image>(typeof(Images));  // �̹��� ������Ʈ�� ������ dictionary�� _objects�� ���ε�. 

        // �̹���(go)�� UI_EventHandler�� ���̰� �Ķ���ͷ� �ѱ� ���� �Լ��� OnDragHandler �׼ǿ� ����Ѵ�.
        GameObject go = GetImage((int)Images.Background).gameObject;
        BindEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

    }

}
