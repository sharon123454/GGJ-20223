using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private int index = 0;
    [SerializeField] private Transform piecePos;
     internal bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            MovePiece();
        }

    }
    void MovePiece()
    {
        transform.position =  Input.mousePosition;
    }
}
