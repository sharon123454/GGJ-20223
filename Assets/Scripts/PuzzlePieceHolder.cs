using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PuzzlePieceHolder : MonoBehaviour
{
    [SerializeField] int index;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PuzzlePiece"))
        {
            PuzzlePiece puzzlePiece = collision.GetComponent<PuzzlePiece>();

            if (puzzlePiece.index == index)
                puzzlePiece.TrySetPieceInPlace(transform.position);
        }
    }
}