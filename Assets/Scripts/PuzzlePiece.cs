using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour , IPointerDownHandler , IBeginDragHandler, IEndDragHandler , IDragHandler
{
    RectTransform rTransform;
    [SerializeField] private int index = 0;
    [SerializeField] private Transform piecePos;
    internal bool isMoving = false;

    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("draging");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}



