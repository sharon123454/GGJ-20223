using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSelf : MonoBehaviour
{
    [SerializeField]
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
