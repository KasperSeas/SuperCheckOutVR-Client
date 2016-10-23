using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThankYou : MonoBehaviour {
    ShoppingCart sc;
    Text total;
    Text paymentID;
    Text capture;

	// Use this for initialization
	void Start () {
        sc = GameObject.Find("ShoppingCartCanvas").GetComponent<ShoppingCart>();
        total = transform.FindChild("Total").gameObject.GetComponent<Text>();
        paymentID = transform.FindChild("paymentID").gameObject.GetComponent<Text>();
        capture = transform.FindChild("Capture").gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update () {
        total.text = sc.grandTotalLabel.text;
	}
}
