using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ThankYou : MonoBehaviour {
    ShoppingCart sc;
    ServerManager sm;
    Text total;
    Text paymentID;
    Text capture;

	// Use this for initialization
	void Start () {
        sc = GameObject.Find("ShoppingCartCanvas").GetComponent<ShoppingCart>();
        total = transform.FindChild("Total").gameObject.GetComponent<Text>();
        paymentID = transform.FindChild("paymentID").gameObject.GetComponent<Text>();
        capture = transform.FindChild("Capture").gameObject.GetComponent<Text>();
        sm = GameObject.Find("Manager").GetComponent<ServerManager>();
    }

    // Update is called once per frame
    void Update () {
    }

    public void updateData(string payment_id, string status)
    {
        Debug.Log("mark");
        paymentID.text = payment_id;
        capture.text = status;
    }
}
