using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class AIDodge : MonoBehaviour
{
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private float attackRange = 5;
    [SerializeField] private int _HP = 100;

    private NavMeshAgent _agent;
    private Vector3 _destination;
    private bool isAttacking;
    private bool dodging;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _playerRef = GameObject.Find("Spine GameObject (Rabbit for Spine)");
    }

    private void Update()
    {
        //_agent.destination = _playerRef.transform.position;

        if (!dodging)
        {
            if (_playerRef)
                SetEnemyDestination(_playerRef.transform.position);

            if (isAttacking)
                SetEnemyDestination(transform.position);

            var currDes = new Vector3(_destination.x, transform.position.y, _destination.z);
            if ((currDes - transform.position).magnitude > attackRange)
            {
                transform.LookAt(currDes);
                _agent.destination = currDes;
            }
            else
            {
                isAttacking = true;
                print("attacking now");
            }
        }
        else
        {
            var currDes = new Vector3(_destination.x, transform.position.y, _destination.z);
            if ((currDes - transform.position).magnitude > 1)
            {
                transform.LookAt(currDes);
                _agent.destination = currDes;
            }
            else
                dodging = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetEnemyDestination(Vector3 newDestination) { /*if (player exists)*/_destination = newDestination; /*else { _destination = transform.position;}*/ }

    public void FinishAttackAnimationEvent()
    {
        isAttacking = false;
    }

    public void EventHandler_PlayerShot(object sender, Vector3 posToDodgeTo)
    {
        dodging = true;
        SetEnemyDestination(posToDodgeTo);
    }

}