using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockON : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.__PlayMusic(AudioManager.Instance.gamePlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
