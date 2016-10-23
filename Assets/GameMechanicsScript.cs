using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMechanicsScript : MonoBehaviour {

	GameObject itemInformation;
	Text itemName;
	Text itemPrice;
	Text itemDescription;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {

		mainCamera = GameObject.Find ("Main Camera");

		setupItemInformationCanvas ();

		Invoke ("showFurniture1Information", 2);
		Invoke ("showFurniture2Information", 4);
		Invoke ("showFurniture3Information", 6);
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

	public void updateItemInformation(GameObject item, Product product) {
		// update data
		string name = product.name;
		string price = product.price.ToString ();
		string description = product.description;
		itemName.text = name;
		itemPrice.text = "$" + price;
		itemDescription.text = description;
		// position overlay in between item and user
		itemInformation.transform.position = 1.0f * (item.transform.position + mainCamera.transform.position);
		Vector3 direction = itemInformation.transform.position - mainCamera.transform.position;
		itemInformation.transform.rotation = Quaternion.LookRotation(direction);
		// show overlay to user
		itemInformation.SetActive (true);
	}

	public void showFurniture1Information() {
		Product product = new Product ("Tall Lamp", 4.99f, "This lamp has very good lighting.");
		updateItemInformation (GameObject.Find ("Furniture1"), product);
	}

	public void showFurniture2Information() {
		Product product = new Product ("Wooden Lamp", 8.99f, "This lamp is very beautiful.");
		updateItemInformation (GameObject.Find ("Furniture2"), product);
	}

	public void showFurniture3Information() {
		Product product = new Product ("Steel Lamp", 9.99f, "This lamp is very sturdy.");
		updateItemInformation (GameObject.Find ("Furniture3"), product);
	}
}
