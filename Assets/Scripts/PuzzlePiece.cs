using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{


    [SerializeField] private int index;
    [SerializeField] private Transform piecePos;
    [SerializeField] Rigidbody2D rigidbody2D;
    internal bool isMoving = false;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lcorner"))
        {
            Debug.Log("yay");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rigidbody2D.isKinematic = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rigidbody2D.isKinematic = false;
    }



    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}



