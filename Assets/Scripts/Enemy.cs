using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;
    [SerializeField] private float distToTarget;
    [SerializeField] private float angleSpeed;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = distToTarget;
        agent.destination = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            Debug.Log(transform.GetInstanceID() + " is close enough");

            //agent.destination = target.position;
            transform.RotateAround(agent.destination, Vector3.up, angleSpeed * Time.deltaTime);

        }
        else
        {
            //transform.RotateAround(agent.destination, Vector3.up, angleSpeed * Time.deltaTime);
        }

        transform.LookAt(target.position, Vector3.up);
    }

    public void SetParams(float distance, float angle)
    {
        distToTarget = distance;
        angleSpeed = angle;
    }
}
