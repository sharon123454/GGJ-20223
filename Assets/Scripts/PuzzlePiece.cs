using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public int index;

    System.Random rand = new System.Random();
    private Rigidbody2D _rigidbody2D;
    private bool endDrag, fin;
    private Vector2 forceDir;
    [SerializeField] float forceMulti;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddForceOnStart();

    }
    public void AddForceOnStart()
    {
        var randomDirection = rand.Next(0, 2);
        if (randomDirection == 0)
        {
            _rigidbody2D.AddForce(Vector2.right * forceMulti * this.transform.position, ForceMode2D.Impulse);

        }
        else
        {
            _rigidbody2D.AddForce(Vector2.left * forceMulti * this.transform.position, ForceMode2D.Impulse);

        }
    }

    public void SetRigidBody(bool IsRigid) { _rigidbody2D.simulated = IsRigid; }

    public void TrySetPieceInPlace(Vector3 positionToSet, int holderIndex)
    {
        if (endDrag && holderIndex == index)
        {
            SetRigidBody(false);
            transform.position = positionToSet;
            GameManager.Instance.RiseCount();
            fin = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!fin)
        {
            endDrag = false;
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = Vector3.zero;
        }
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