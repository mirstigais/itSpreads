﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    int speed;

    public int waypointIndex;
    private float dist;

    [HideInInspector]
    public Vector3 origin;
    public Vector3 destination;

    [HideInInspector]
    public Animator anim;
    EnemyState stateScript;
    EnemyState.EnemyStates state;
    void Start()
    {
        stateScript = this.transform.GetComponent<EnemyState>();
        state = stateScript.state;
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
        EnemyState.EnemyStates state = stateScript.state;
        if (state == EnemyState.EnemyStates.patrolling)
        {
            //Debug.Log("Is patrolling");
            destination = waypoints[waypointIndex].transform.position;
            origin = transform.position;
            dist = Vector3.Distance(origin, destination);
            if (dist < 1f) IncreaseIndex();
            PatrolAround();
        }
    }

    void PatrolAround()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        anim.SetBool("isWalking", true);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length) waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex]);
    }
}
