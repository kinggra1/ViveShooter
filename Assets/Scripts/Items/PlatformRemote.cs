using UnityEngine;
using System.Collections;
using System;

public class PlatformRemote : MonoBehaviour, Tool
{
    public GameObject platform;
    public GameObject playerHead;
    public float maxHorizontalAcceleration;
    public float maxForwardAcceleration;
    public float maxForwardVelocity;
    public float maxHorizontalVelocity;

    private float horizontalVelocity = 0f;
    private float forwardVelocity = 0f;

    void Update()
    {
        Vector3 temp = platform.transform.position;

        temp += Vector3.forward * forwardVelocity * Time.deltaTime;
        temp += Vector3.right * horizontalVelocity * Time.deltaTime;

        platform.transform.position = temp;
    }

    public void gripPull()
    {
        throw new NotImplementedException();
    }

    public void gripRelease()
    {
        throw new NotImplementedException();
    }

    public void touchpadPos(Vector2 touchpadPos)
    {
        Vector3 playerHeading = new Vector3(playerHead.transform.forward.x, 0f, playerHead.transform.forward.z).normalized;
        Vector3 playerRight = new Vector3(playerHead.transform.right.x, 0f, playerHead.transform.right.z).normalized;

        forwardVelocity = Mathf.Min(forwardVelocity + (touchpadPos.y * Time.deltaTime * maxForwardAcceleration), maxForwardVelocity);
        horizontalVelocity = Mathf.Min(horizontalVelocity + (touchpadPos.x * Time.deltaTime * maxHorizontalAcceleration), maxHorizontalVelocity);

    }

    public void triggerPull()
    {
        throw new NotImplementedException();
    }

    public void triggerRelease()
    {
        throw new NotImplementedException();
    }
}
