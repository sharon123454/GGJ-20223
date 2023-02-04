using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private GameObject playerRef;
    [SerializeField] private float speed = 10f;

    public int _HP = 100;
    private NavMeshAgent _agent;
    private Vector3 _destination;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetEnemyDestination(transform.position);
    }

    private void Update()
    {
        if (playerRef)
            SetEnemyDestination(playerRef.transform.position);

        var currDes = new Vector3(_destination.x, transform.position.y, _destination.z);
        if ((currDes - transform.position).magnitude > 1)
        {
            transform.LookAt(currDes);
            _agent.destination = currDes * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void SetEnemyDestination(Vector3 newDestination) { /*if (player exists)*/_destination = newDestination; /*else { _destination = transform.position;}*/ }

}