using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int _HP = 100;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bullet")
        {
          //  Destroy(other.gameObject);
          print("HITTTTTTTTTTTTT");
            Destroy(gameObject);
        }
    }
}
