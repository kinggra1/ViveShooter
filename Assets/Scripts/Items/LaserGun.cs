using UnityEngine;
using System.Collections;
using System;

public class LaserGun : MonoBehaviour, Tool {

    private AudioSource sfx;

    private LineRenderer sightLine;
    //private List<LineRenderer> shots = new List<LineRenderer>();

    public float fireDuration = 0.05f;

    public GameObject gunTip;
    public GameObject laserShot_prefab;

    // Use this for initialization
    void Start () {
        sfx = GetComponent<AudioSource>();
	}


    public void gripPull()
    {
        throw new NotImplementedException();
    }

    public void gripRelease()
    {
        throw new NotImplementedException();
    }

    public void triggerPull()
    {
        StartCoroutine(FireLaser());
        sfx.pitch = (1f + UnityEngine.Random.Range(-0.2f, 0.2f));
        sfx.Play();
    }

    public void triggerRelease()
    {
        throw new NotImplementedException();
    }

    public void touchpadPos(Vector2 touchpadPos)
    {
        throw new NotImplementedException();
    }



    IEnumerator FireLaser()
    {
        Vector3 shotOrigin = gunTip.transform.position;
        Vector3 shotDest = shotOrigin + gunTip.transform.forward * 1000f;

        RaycastHit hitInfo;
        if (Physics.Raycast(shotOrigin, shotDest, out hitInfo))
        {
            Destructible target = hitInfo.collider.gameObject.GetComponent<Destructible>();
            if (target != null)
            {
                target.destroy();
            }
        }

        GameObject temp = Instantiate(laserShot_prefab);
        LineRenderer shot = temp.GetComponent<LineRenderer>();
        shot.SetPositions(new Vector3[] { shotOrigin, shotDest });

        float time = 0f;
        while (time < fireDuration)
        {
            shot.SetPosition(0, gunTip.transform.position);
            time += Time.deltaTime;
            yield return null;
        }

        Destroy(temp);
    }
}
