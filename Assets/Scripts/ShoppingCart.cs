using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShoppingCart : MonoBehaviour {

	public List<Product> products;
	public GameObject itemCell;


	void Start(){
		products = new List<Product> ();
		Product prod = new Product("Blue Paint", 8.0f, "", "");
		addItem (prod);
		Debug.Log (products[0].name);
	}

	void addItem(Product product){
		products.Add (product);
		GameObject ic = Instantiate(itemCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

		RectTransform rt = ic.GetComponent<RectTransform> ();
		rt.sizeDelta = new Vector2( 1.95f, 0.15f);
		rt.localPosition = new Vector3 (-0.45f, 1.55f, 1.7f); 
		ic.transform.parent = transform;
	}
}
