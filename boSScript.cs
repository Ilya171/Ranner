using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boSScript : MonoBehaviour
{
    Vector3 startPos = new Vector3(145f,0f,293f);
     int xp = 5;
    public int Xp
    {
        get
        {
            return xp;
        }
        set
        {
            xp = value;
            if(xp<=0)
            {
                bossDead();
            }
        }
    }
    
    void bossDead()
    {
        Instantiate(_ragdoll, transform.position, Quaternion.identity, null);        
        KillSelf();
    }

    private void Start()
    {
        PlayerManager.instance.endGameEnemyAlive++;
    }


    [Header("Shoot")]
    public Animator _animC;
    public Transform handPos;
    public Skull _skull;
    public GameObject _ragdoll;

    [Header("EndGame")]
    public NavMeshAgent _navAgent;
    public Transform _endGameTarget;
    public bool _endTriggered;

    private void OnEnable()
    {
        EnemyManager.EnemyShoot += EnemyManager_EnemyShoot;
        AgentManager.Complete += StartEndGame;

        if (!_animC.isActiveAndEnabled)
        {
            _animC.enabled = true;
        }
    }

    private void OnDisable()
    {
        EnemyManager.EnemyShoot -= EnemyManager_EnemyShoot;
        AgentManager.Complete -= StartEndGame;
        //AgentPool._agentPool.livingAgents--;
    }


    void Awake()
    {
        _animC = GetComponent<Animator>();
    }

    void EnemyManager_EnemyShoot()
    {
        _animC.SetTrigger("Throw");
    }

    public void Throw()
    {
        Vector3 newPos = handPos.position;
        newPos.y = 1f;
        Quaternion faceDirection = transform.rotation;
        Instantiate(_skull, newPos, faceDirection);
    }
   

    public void KillSelf()
    {
        if (_endTriggered)
        {
            PlayerManager.instance.endGameEnemyAlive--;
        }
        gameObject.SetActive(false);
    }

    public void StartEndGame()
    {
        _endTriggered = true;
        _animC.SetTrigger("Run");        
        _navAgent = GetComponent<NavMeshAgent>();
        _endGameTarget = EnemyManager.instance.endGameTarget;
        _navAgent.SetDestination(_endGameTarget.position);
    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PlayerBullet"))
        {
            Xp--;
            Destroy(other.gameObject);

        }
    }
}
