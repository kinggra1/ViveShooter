using UnityEngine;
using System.Collections;

public class TimedDestructor : MonoBehaviour {

    public float timeToDeath = 2f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timeToDeath);
	}
}
