using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 2.0f;
    public float dashSpeed = 20.0f;
    public float dashDuration = 0.5f;
    public float skinWidth = 0.1f;
    public LayerMask obstacleMask;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 mousePosition;
    private float dashTime;
    public bool isDashing;

    private CapsuleCollider capsuleCollider;
    private Vector3 movementDirection;
    private int clamp2;
    public VisualEffect fartPack;
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        float test = transform.rotation.y;
        transform.rotation = Quaternion.Euler(0,Mathf.Clamp(transform.rotation.y,-45,45), 0);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        movementDirection *= speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            dashTime = Time.time + dashDuration;
            isDashing = true;
            fartPack.playRate = 10;
            fartPack.gameObject.SetActive(true);
        }

        if (isDashing)
        {
            movementDirection = movementDirection.normalized * dashSpeed * Time.deltaTime;
            if (Time.time >= dashTime)
            {
                isDashing = false;
                fartPack.playRate = 10;
                fartPack.gameObject.SetActive(false);

            }
        }

        float distance = movementDirection.magnitude + skinWidth;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, capsuleCollider.radius, movementDirection, distance, obstacleMask);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (!hit.collider.isTrigger)
                {
                    movementDirection = Vector3.zero;
                    break;
                }
            }
        }

        transform.Translate(movementDirection, Space.World);

        Vector3 lookDirection = movementDirection;
        lookDirection.y = 0;
        if (lookDirection.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * sensitivity);
        }
    }
}
