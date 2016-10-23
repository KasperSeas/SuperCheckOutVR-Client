using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShoppingCart : MonoBehaviour {

	public List<Product> products;

	void Start(){
		products = new List<Product> ();
		Product prod = new Product("Blue Paint", 8.0f);
		addItem (prod);
		Debug.Log (products[0].name);
	}

	void addItem(Product product){
		products.Add (product);
	}
}
