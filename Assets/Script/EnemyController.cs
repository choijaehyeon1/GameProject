using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private static GameObject sightPrefab = null;

    public float DeadTime = 0f;
    public Transform target;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private Animator animator;

    [SerializeField] private float stayTime;
    [SerializeField] private float attackTime;
    [SerializeField] private PlayerParams playerParams;

    public MonsterStat Monsterstat;

    private EnemySightComponent sight;

    private void Reset()
    {
        nav = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        attackTime = 0f;
        stayTime = 0f;
        if ((sight = GetComponentInChildren<EnemySightComponent>()) == null)
        {
            if (!sightPrefab)
                sightPrefab = Resources.Load<GameObject>("Sight");
            sight = Instantiate(sightPrefab, transform).GetComponent<EnemySightComponent>();
        }
        sight.OnSightUpdated += OnSightUpdate;

    }

    private void Update()
    {
        playerParams = GameObject.Find("Player").GetComponent<PlayerParams>();
    }
    private void FixedUpdate()
    {
        float speed = nav.desiredVelocity.magnitude;
        

        if (Monsterstat.Hp >= 0)
        {
            if (target)
            {
                float distance = Vector3.Distance(transform.position, target.position);


                if (distance < 3f)
                {
                    attackTime += Time.fixedDeltaTime;

                    if (attackTime > 3f)
                    {

                        attackTime = 0f;
                        animator.SetTrigger("Attack");
                        if (playerParams.stat.Defense >= Monsterstat.Atk)
                        {
                            Monsterstat.Atk = 0;
                            playerParams.stat.Hp -= Monsterstat.Atk;
                        }
                        else
                        {
                            playerParams.stat.Hp -= Monsterstat.Atk - playerParams.stat.Defense;
                        }
                        
                    }

                    nav.isStopped = true;
                }
                else
                {
                    nav.isStopped = false;
                }
                nav.SetDestination(target.position);
            }
            else
            {
                if (speed <= 0f)
                {
                    stayTime += Time.fixedDeltaTime;

                    if (stayTime > 3f)
                    {
                        nav.SetDestination(transform.position + new Vector3(Random.Range(-10f, 10f), 0f,
                            Random.Range(-10f, 10f)));
                        stayTime = 0f;
                    }
                }
            }

            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.SetBool("Dead", true);

            DeadTime += Time.fixedDeltaTime;

            if(DeadTime >= 4f)
            {
                playerParams.stat.Exp += Monsterstat.Exp;
                playerParams.stat.Gold += (int)Monsterstat.Gold;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnSightUpdate(Collider other)
    {
        if (other)
        {
            target = other.transform;
        }
        else
        {
            target = null;
        }
    }

}
