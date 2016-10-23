namespace VRTK.Examples
{
using UnityEngine;
using System.Collections;


public class ShowHUDOnInteraction : VRTK_InteractableObject {

    public override void StartTouching(GameObject currentTouchingObject)
    {
         base.StartTouching(currentTouchingObject);
            Debug.Log("Started touching current object");
    }

    public override void StopTouching(GameObject currentTouchingObject)
    {
         base.StartTouching(currentTouchingObject);
            Debug.Log("Stopped touching current object");
    }

        // Use this for initialization
     protected override void Start() {

    }

    // Update is called once per frame
    protected override void Update() {

    }
}
}
