using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public float timeToMe = 10f;
    public float waitAtMe = 0f;
    public bool blocking = false;


    public bool isBlocking()
    {
        return blocking;
    }

    public void block()
    {
        blocking = true;
    }

    public void unblock()
    {
        blocking = false;
    }

    public float getTravelTime()
    {
        return timeToMe;
    }

    public float getWaitTime()
    {
        return waitAtMe;
    }
}
