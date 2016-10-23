using UnityEngine;
using System.Collections;

public class ProductDescription : MonoBehaviour {

	public string name = "";
	public float price = 0.0f;
	public string description = "";
	public string brand = "";

	Product product;

	// Use this for initialization
	void Start () {
		string price = string.Format("{0:0.00}", this.price);    
		Debug.Log ("Added product: " + brand + " " + name + ", $" + price + ", " + description);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
