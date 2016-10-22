using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class PickUpScript : MonoBehaviour {

    public Rigidbody rigidBodyAttachPoint;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObj;
    SteamVR_LaserPointer laserPointer;

    FixedJoint joint;

	// Use this for initialization
	void Awake () {

        trackedObj = GetComponent<SteamVR_TrackedObject>();
        laserPointer = GetComponent<SteamVR_LaserPointer>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        // Get the triggers and read from the controller data	
       if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("You are Pressing Down");
            if (laserPointer.pointer != null)
            {
                laserPointer.pointer.SetActive(true);
            }
        }

       if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("You are Pressing Up");
            if (laserPointer.pointer != null)
            {
                laserPointer.pointer.SetActive(false);
            }
        }
	}

    void OnTriggerStay (Collider col)
    {
        // If the rigid body collides with the picked up object, then add to parent 
        if (joint == null && device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Touching an object");
            joint = col.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = rigidBodyAttachPoint;
        } else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            GameObject go = joint.gameObject;
            Rigidbody rigidBody = go.GetComponent<Rigidbody>();
            Object.Destroy(joint);
            joint = null;
            TossObject(rigidBody);
        }
        
    }

    void TossObject (Rigidbody rigidbody)
    {
        Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
        if (origin != null)
        {
            Debug.Log("Origin exists! it is " + origin);
            rigidbody.velocity = origin.TransformVector(device.velocity);
            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
        } else
        {
            Debug.Log("Origin does not exist! it is " + origin);
            rigidbody.velocity = device.velocity;
            rigidbody.angularVelocity = device.angularVelocity;
        }

    }
}
