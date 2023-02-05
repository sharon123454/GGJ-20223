using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance._PlayMusic(AudioManager.Instance.DeskMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
