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

        int counter = 0;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                if (counter == 0)
                {
                    GameObject summaryCanvas = GameObject.Find("SummaryCanvas");
                    summaryCanvas.transform.position = new Vector3(summaryCanvas.transform.position.x, 1.33f, summaryCanvas.transform.position.z);
                    counter++;
                }
                else
                {
                    GameObject summaryCanvas = GameObject.Find("SummaryCanvas");
                    summaryCanvas.SetActive(false);
                    GameObject shoppingCartCanvas = GameObject.Find("ShoppingCartCanvas");
                    shoppingCartCanvas.SetActive(false);
                    counter--;
                    GameObject thankYouCanvas = GameObject.Find("ThankYouCanvas");
                    thankYouCanvas.transform.position = new Vector3(thankYouCanvas.transform.position.x, 1.41f, thankYouCanvas.transform.position.z);
                }
            }
        }

        public void DoPointerIn(object sender, DestinationMarkerEventArgs args)
        {
            if (args.target)
            {
                // Debug.Log("Pointer in " + args.target.name);
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
                        ShoppingCart shoppingCart = GameObject.Find("ShoppingCartCanvas").GetComponent<ShoppingCart>();
                        shoppingCart.addItem(targetObject.gameObject.GetComponent<ProductDescription>().product);
                    }
                }
            }
        }

        public void DoPointerOut(object sender, DestinationMarkerEventArgs args)
        {
            if (args.target)
            {
                // Debug.Log("Pointer out " + args.target.name);
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
            // Debug.Log("Destination set: " + args.target.name);
            Transform targetObject = args.target;
            if (targetObject.tag == "Selectable")
            {
                // Debug.Log("Object was selectable");
                if (targetObject.tag == "Selectable")
                {
                    MechanicsScript gameMechanic = GameObject.Find("Mechanics").GetComponent<MechanicsScript>();
                    gameMechanic.itemInformation.SetActive(false);
                }
            }
        }
    }
}
