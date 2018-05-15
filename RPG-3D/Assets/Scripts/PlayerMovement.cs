using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    private NavMeshAgent mNavMeshAgent;
    private bool mRunning;

    // Use this for initialization
    void Start () {

        mNavMeshAgent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //sprawdzamy czy jest wcisniete

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit,100 ))
            {
                mNavMeshAgent.destination = hit.point;
            }
        }
        /*
         * // to do animacji potem  !!!!!!!!
        if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance) 
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }
        */
    }
}
