using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIONUI : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("This");
        }
    }
}
