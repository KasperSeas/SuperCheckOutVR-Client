namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;

    [RequireComponent(typeof(SteamVR_TrackedObject))]
    public class PointerEventListener : MonoBehaviour
    {

        SteamVR_Controller.Device device;
        SteamVR_TrackedObject trackedObj;

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
            trackedObj = GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObj.index);
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
                    gameMechanic.updateItemInformationPointing(GameObject.Find(targetObject.name));
                    if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        Debug.Log("Device down pressed!!!!!!!!!");
                        gameMechanic.itemInformation.SetActive(false);
                        targetObject.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void DoPointerOut(object sender, DestinationMarkerEventArgs args)
        {
            if (args.target)
            {
                Debug.Log("Pointer out " + args.target.name);
                Transform targetObject = args.target;
                if (targetObject.tag == "Selectable")
                {
                    MechanicsScript gameMechanic = GameObject.Find("Mechanics").GetComponent<MechanicsScript>();
                    gameMechanic.itemInformation.SetActive(false);
                }
            }
        }

        public void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs args)
        {
            Debug.Log("Destination set: " + args.target.name);
            Transform targetObject = args.target;
            if (targetObject.tag == "Selectable")
            {
                Debug.Log("Object was selectable");
                if (targetObject.tag == "Selectable")
                {
                    MechanicsScript gameMechanic = GameObject.Find("Mechanics").GetComponent<MechanicsScript>();
                    gameMechanic.itemInformation.SetActive(false);
                }
            }
        }
    }
}
