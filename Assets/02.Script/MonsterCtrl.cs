using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // AI 네임스페이스

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] private Transform MonsterTr;
    [SerializeField] private Transform PlayerTr;
    private Animator anime;
    private NavMeshAgent agent;
    [Range(5.0f, 20.0f)] public float traceDist = 10.0f;

    void Start()
    {
        MonsterTr = transform;
        PlayerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(PlayerTr.position, MonsterTr.position);

        if (distance <= traceDist) {
            agent.SetDestination(PlayerTr.position);
            agent.isStopped = false;
            anime.SetBool("IsTrace", true);
        }
        else {
            agent.isStopped = true;
            anime.SetBool("IsTrace", false);
        }
    }
}
