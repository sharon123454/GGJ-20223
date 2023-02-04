using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSelf : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
