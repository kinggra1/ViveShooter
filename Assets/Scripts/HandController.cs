using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandController : MonoBehaviour {

    private Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId grip = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Vector2 touchpadPos;

    public Tool tool;


	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
        tool = GetComponentInChildren<Tool>();
    }

	void Update () {


        if (controller.GetPressDown(trigger))
        {
            if (tool != null)
            {
                tool.triggerPull();
            }
        }

        if (controller.GetPressUp(trigger))
        {
            if (tool != null)
            {
                tool.triggerRelease();
            }
        }



        if (controller.GetPressDown(grip))
        {
            if (tool != null)
            {
                tool.gripPull();
            }
        }

        touchpadPos.x = controller.GetState().rAxis0.x;
        touchpadPos.y = controller.GetState().rAxis0.y;

        if (touchpadPos != Vector2.zero)
        {
            if (tool != null)
            {
                tool.touchpadPos(touchpadPos);
            }
        }

    }

	void OnTriggerEnter(Collider other) {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
