using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    public float orthographicSize = 5;
    public float aspect = 1.33f;
    public Camera camera;
    public float rotationSpeed = 10;
    void Start()
    {
       // camera.orthographic = true;
        //camera.orthographicSize = orthographicSize;
        camera.aspect = aspect;
        camera.transform.rotation = Quaternion.Euler(new Vector3(45, 45, 0));
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.RotateAround(transform.position, Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
