using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    public Transform _player;
    public int cameraRise;
    public int cameraSide;
    public int cameraFrontBack;
    public void Start()
    {

    }
    void LateUpdate()
    {
        transform.position = new Vector3(_player.position.x + cameraSide, _player.position.y + cameraRise, _player.position.z + cameraFrontBack);
    }
}
