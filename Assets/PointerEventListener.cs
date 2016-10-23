﻿namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;

    public class PointerEventListener : MonoBehaviour
    {

        VRTK_SimplePointer pointer;

        // Use this for initialization
        void Start()
        {
            if (GetComponent<VRTK_SimplePointer>() == null)
            {
                return;
            }
            GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
            GetComponent<VRTK_SimplePointer>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
            GetComponent<VRTK_SimplePointer>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoPointerIn(object sender, DestinationMarkerEventArgs args)
        {
            if (args.target)
            {
                Debug.Log("Pointer in " + args.target.name);
                Transform targetObject = args.target;
                if (targetObject.tag == "Selectable")
                {

                    MechanicsScript gameMechanic = GameObject.Find("Mechanics").GetComponent<MechanicsScript>();
                    gameMechanic.updateItemInformation(GameObject.Find(targetObject.name));
                }
            }
        }

        public void DoPointerOut(object sender, DestinationMarkerEventArgs args)
        {
            if (args.target)
            {
                Debug.Log("Pointer out " + args.target.name);
            }
        }

        public void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs args)
        {
            Debug.Log("Destination set: " + args.target.name);
            Transform targetObject = args.target;
            if (targetObject.tag == "Selectable")
            {
                Debug.Log("Object was selectable");
                Rigidbody rigidbody = targetObject.GetComponent<Rigidbody>();
                rigidbody.AddForce(targetObject.transform.forward * 2.0f);
            }
        }
    }
}
