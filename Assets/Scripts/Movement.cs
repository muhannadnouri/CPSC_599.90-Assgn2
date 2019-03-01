using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    //destination marker reference
    public GameObject markerGoal;

    //parent position
    Vector3 parentPos;

    //navmesh component reference
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    // function to track position of second marker
    void MoveToTarget()
    {
        if (markerGoal.active)
        {
            parentPos = markerGoal.transform.parent.position;
            agent.SetDestination(parentPos);
        }
    }
}
