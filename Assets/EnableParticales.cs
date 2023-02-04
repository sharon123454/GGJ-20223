using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableParticales : MonoBehaviour
{
    public GameObject test;
    public GameObject particle;

    void Update()
    {
        if (test.activeInHierarchy)
            particle.SetActive(true);
        else
            particle.SetActive(false);
    }
}
