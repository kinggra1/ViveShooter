using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

    public GameObject playarea;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playarea.transform.position = this.transform.position;
	}
}
