using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PackHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CardPack cardPack;

    Vector2 initialPosition;

    RectTransform rect;

    public bool canDrag = true;

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && canDrag)
        {
            rect.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cardPack.packManager.HasDroppedCorrectly(this);
        rect.anchoredPosition = initialPosition;
    }

    void Start()
    {
        rect = GetComponent<RectTransform>();
        initialPosition = rect.anchoredPosition;
    }

    void Update()
    {

    }
}
