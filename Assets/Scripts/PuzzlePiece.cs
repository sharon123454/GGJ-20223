using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public int index;

    System.Random rand = new System.Random();
    private Rigidbody2D _rigidbody2D;
    private bool endDrag = false;
    private Vector2 forceDir;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //var temp = rand.Next(-1, 1);
        //if (temp >= 0)
        //{
        //    forceDir = new Vector2(1000, 600);
        //    _rigidbody2D.AddForce(forceDir.normalized * 10, ForceMode2D.Impulse);
        //    print("Right");
        //}
        //else
        //{
        //    forceDir = new Vector2(850, 600);
        //    _rigidbody2D.AddForce(forceDir.normalized * 10, ForceMode2D.Impulse);
        //    print("Left");
        //}

    }

    public void SetRigidBody(bool IsRigid) { _rigidbody2D.simulated = IsRigid; }

    public void TrySetPieceInPlace(Vector3 positionToSet, int holderIndex)
    {
        if (endDrag && holderIndex == index)
        {
            SetRigidBody(false);
            transform.position = positionToSet;
            GameManager.Instance.RiseCount();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        endDrag = false;
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