using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMouseTopBottom : MonoBehaviour
{
    public static FindMouseTopBottom Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private int screenHalf;
    private float screenMiddleY;

    private void Start()
    {
        screenMiddleY = Screen.height / 1.55f;
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (mousePosition.y < screenMiddleY)
        {
            screenHalf = 1;
        }
        else
        {
            screenHalf = 2;
        }

    }

    public bool isTopSide()
    {
        if (screenHalf == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
