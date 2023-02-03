using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunPivot;
    public GameObject bulletPrefab;
    public LayerMask floorMask;
    public float shootingForce = 10.0f;
    public float rotationSpeed = 100.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;
    public float sensitivity = 45.0f;
    public float fireRate = 0.5f;
    private float nextFireTime;
    public Vector3 lockRotation;

    void LateUpdate()
    {
       // transform.localRotation = Quaternion.Euler(lockRotation);
    }
    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = (worldPos - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(cameraRay, out floorHit, 100, floorMask))
        {
            mousePos = floorHit.point;
        }

        Vector3 lookDirection = mousePos - transform.position;
        lookDirection.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        if (lookRotation.y >= 45)
        {
            return;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * sensitivity);

        float pivotAngle = gunPivot.localEulerAngles.z;
        pivotAngle = Mathf.Clamp(pivotAngle, minAngle, maxAngle);
        gunPivot.localEulerAngles = new Vector3(0, 0, pivotAngle);

        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPivot.position, gunPivot.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(gunPivot.forward * shootingForce, ForceMode.Impulse);
    }
}
