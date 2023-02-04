using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class AIDash : MonoBehaviour
{
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private float _attackRange = 5f;
    [SerializeField] private float _dashSpeed = 5f;
    [SerializeField] private float _stunDuration = 3f;
    [SerializeField] private int _HP = 100;

    private WaitForSeconds stunDuration;
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private bool _isDashing, _stunned;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        stunDuration = new WaitForSeconds(_stunDuration);
    }

    private void Start()
    {
        _playerRef = GameObject.Find("Spine GameObject (Rabbit for Spine)");
    }


    private void Update()
    {
        if (_stunned)
            return;

        if (_playerRef)
            SetEnemyDestination(_playerRef.transform.position);

        if (_isDashing)
        {
            var direction = new Vector3(_playerRef.transform.position.x, transform.position.y, _playerRef.transform.position.z);
            if ((direction - transform.position).magnitude > 0.2f)
            {
                transform.LookAt(direction);
                transform.position += direction.normalized * Time.deltaTime * _dashSpeed;
            }
        }
        else
        {
            var currDes = new Vector3(_destination.x, transform.position.y, _destination.z);
            if ((currDes - transform.position).magnitude > _attackRange)
            {
                transform.LookAt(currDes);
                _agent.destination = currDes;
            }
            else
            {
                if (_destination != transform.position)
                {
                    _isDashing = true;

                    print("dashing now");
                    Invoke("FinishDashAnimationEvent", 3);
                }
            }
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

    public void FinishDashAnimationEvent()
    {
        _isDashing = false;
        StartCoroutine(Stun());
    }

    private IEnumerator Stun()
    {
        _stunned = true;
        yield return stunDuration;
        _stunned = false;
    }

}