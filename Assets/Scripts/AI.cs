using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    [SerializeField] private GameObject _playerRef;
    [SerializeField] private float attackRange = 1;
    [SerializeField] private int _HP = 100;
    public AiSpineAnim anim;
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private bool isAttacking;

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
            if (_destination != transform.position)
            {
                anim.Attack();
                isAttacking = true;
                print("attacking now");
                if (SceneManager.GetActiveScene().buildIndex > 6)
                {
                    AudioManager.Instance.PlayVFX(AudioManager.Instance.hitPlayer);

                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (SceneManager.GetActiveScene().buildIndex > 6)
            {
            AudioManager.Instance.PlayVFX(AudioManager.Instance.hitEnemy);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetEnemyDestination(Vector3 newDestination) { /*if (player exists)*/_destination = newDestination; /*else { _destination = transform.position;}*/ }

    public void FinishAttackAnimationEvent()
    {
        isAttacking = false;
    }

}