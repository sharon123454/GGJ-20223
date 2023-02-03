using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public int index;

    private Rigidbody2D _rigidbody2D;
    private bool endDrag = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetRigidBody(bool IsRigid) { _rigidbody2D.simulated = IsRigid; }

    public void TrySetPieceInPlace(Vector3 positionToSet)
    {
        if (endDrag)
        {
            SetRigidBody(false);
            transform.position = positionToSet;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!endDrag)
            transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rigidbody2D.isKinematic = false;
        endDrag = true;
    }

}