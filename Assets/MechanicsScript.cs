using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MechanicsScript : MonoBehaviour {

	GameObject itemInformation;
	Text itemName;
	Text itemPrice;
	Text itemDescription;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {

		mainCamera = GameObject.Find ("Camera (eye)");

		setupItemInformationCanvas ();
        Debug.Log(mainCamera);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setupItemInformationCanvas() {
		itemInformation = GameObject.Find ("ItemInformation");
		itemInformation.SetActive (false);
		Text[] labels = itemInformation.GetComponentsInChildren <Text> ();
		foreach (Text label in labels) {
			switch (label.name) {
			case "ItemName":
				itemName = label;
				break;
			case "ItemPrice":
				itemPrice = label;
				break;
			case "ItemDescription":
				itemDescription = label;
				break;
			}
		}
	}

	public void updateItemInformation(GameObject item) {
        // grab the product component
        ProductDescription productDescription = item.GetComponent<ProductDescription>();
        Product product = productDescription.product;
		// update data
		string name = product.name;
        Debug.Log(name);
		string price = product.price.ToString ();
		string description = product.description;
		itemName.text = name;
		itemPrice.text = price;
		itemDescription.text = description;
		// position overlay in between item and user
		itemInformation.transform.position = 0.5f * (item.transform.position + mainCamera.transform.position);
		Vector3 direction = itemInformation.transform.position - mainCamera.transform.position;
		itemInformation.transform.rotation = Quaternion.LookRotation(direction);
        Debug.Log(itemInformation.transform);
		// show overlay to user
		itemInformation.SetActive (true);
	}

	public void showFurniture1Information() {
		Debug.Log ("1");
		Product product = new Product ("Tall Lamp", 4.99f, "This lamp has very good lighting.", "");
	}

	public void showFurniture2Information() {
		Debug.Log ("2");
		Product product = new Product ("Wooden Lamp", 8.99f, "This lamp is very beautiful.", "");
	}

	public void showFurniture3Information() {
		Debug.Log ("3");
		Product product = new Product ("Steel Lamp", 9.99f, "This lamp is very sturdy.", "");
	}
}
