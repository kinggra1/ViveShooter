using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailsPlatform : MonoBehaviour {

    public GameObject waypointsParent;
    public bool loop;

    private List<Waypoint> waypoints = new List<Waypoint>();
    private int currentIndex = -1;
    private Waypoint currentWaypoint;
    private Vector3 lastPos;
    private Vector3 nextPos;
    private float travelTime;
    private float waitTime;

    private float travelClock = 0f;
    private float waitClock = 0f;

	// Use this for initialization
	void Start () {
	    foreach(Waypoint w in waypointsParent.GetComponentsInChildren<Waypoint>()) {
            waypoints.Add(w);
        }

        updateValues();
	}
	
	// Update is called once per frame
	void Update () {

        if (currentWaypoint == null)
        {
            return;
        }

	    if (transform.position != nextPos)
        {
            travelClock += Time.deltaTime;
            transform.position = Vector3.Lerp(lastPos, nextPos, travelClock/travelTime);
        }
        else // destination reached
        {

            waitClock += Time.deltaTime;
            if (currentWaypoint.isBlocking())
            {
                return;
            }

            if (waitClock >= waitTime)
            {
                updateValues();
            }
            
        }
	}

    private void updateValues()
    {
        travelClock = 0f;
        waitClock = 0f;
        currentWaypoint = nextWaypoint();
        lastPos = transform.position;
        nextPos = currentWaypoint.transform.position;
        travelTime = currentWaypoint.getTravelTime();
        waitTime = currentWaypoint.getWaitTime();
    }

    private Waypoint nextWaypoint()
    {
        if (waypoints.Count > 0)
        {
            if (currentIndex++ >= waypoints.Count)
            {
                if (loop)
                {
                    currentIndex = 0;
                }
                else
                {
                    return null;
                }
            }

            return waypoints[currentIndex];
        }

        return null;
    }
}
