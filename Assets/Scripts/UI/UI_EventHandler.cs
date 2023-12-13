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

    public void OnPointerClick(PointerEventData eventData) // 클릭 이벤트 오버라이딩
    {
        OnClickHandler?.Invoke(eventData); // 클릭와 관련된 액션 실행 // 클릭와 관련된 액션 실행
    }

    //시도의 흔적
    //public void OnPointerClick(PointerEventData eventData,Item item) 
    //{
    //    if (OnClickHandler != null)
    //        OnItemClickHandler.Invoke(eventData,item); 
    //}

    public void OnDrag(PointerEventData eventData) // 드래그 이벤트 오버라이딩
    {
        OnDragHandler?.Invoke(eventData); // 드래그와 관련된 액션 실행 // 드래그와 관련된 액션 실행
    }
}
