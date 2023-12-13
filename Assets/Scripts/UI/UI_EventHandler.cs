using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    //public Action<PointerEventData,Item> OnItemClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData) // Ŭ�� �̺�Ʈ �������̵�
    {
        OnClickHandler?.Invoke(eventData); // Ŭ���� ���õ� �׼� ���� // Ŭ���� ���õ� �׼� ����
    }

    //�õ��� ����
    //public void OnPointerClick(PointerEventData eventData,Item item) 
    //{
    //    if (OnClickHandler != null)
    //        OnItemClickHandler.Invoke(eventData,item); 
    //}

    public void OnDrag(PointerEventData eventData) // �巡�� �̺�Ʈ �������̵�
    {
        OnDragHandler?.Invoke(eventData); // �巡�׿� ���õ� �׼� ���� // �巡�׿� ���õ� �׼� ����
    }
}
