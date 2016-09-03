using UnityEngine;
using System.Collections;
using System;

public class TargetCube : MonoBehaviour, Destructible
{

    public AudioClip sfx;


    public GameObject explosionPrefab;

    public void destroy()
    {
        AudioSource.PlayClipAtPoint(sfx, transform.position);
        Instantiate(explosionPrefab).transform.position = this.transform.position;
        Destroy(gameObject);
    }

    public void hit(float damage)
    {
        throw new NotImplementedException();
    }

    public void knockBack(Vector3 direction, float force)
    {
        throw new NotImplementedException();
    }
}
