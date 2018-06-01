using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCards : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool onPointer = false;
    public PackManager packHandler;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(packHandler.tempCompleteList.Count <= 0)
            onPointer = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onPointer = false;
    }
}
