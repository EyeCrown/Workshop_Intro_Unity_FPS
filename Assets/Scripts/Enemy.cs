using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private ParticleSystem particleSystem;

    public Transform target;
    [SerializeField] private float distToTarget;
    [SerializeField] private float angleSpeed;

    public List<Transform> patrolPoints;
    private int idPatrol = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.stoppingDistance = distToTarget;
        agent.destination = patrolPoints[0].position;

        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(idPatrol);
        if (Vector3.Distance(transform.position, agent.destination) <= 1f)
        {
            particleSystem.Emit(10);
            idPatrol++;
            idPatrol = idPatrol % patrolPoints.Count;

            agent.destination = patrolPoints[idPatrol].position;
        }

        transform.LookAt(target.position, Vector3.up);
    }

    public void SetParams(float distance, float angle, List<Transform> patrolList)
    {
        distToTarget = distance;
        angleSpeed = angle;
        patrolPoints = patrolList;
        agent.destination = patrolPoints[idPatrol].position;
    }
}
