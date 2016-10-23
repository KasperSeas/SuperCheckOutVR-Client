using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShoppingCart : MonoBehaviour {

	public List<Product> products;
	public GameObject itemCell;
	public int numOfItems;


	void Start(){
		products = new List<Product> ();
		numOfItems = 0;
		Product prod1 = new Product("Chair", 245.34f, "", "Apple");
		Product prod2 = new Product("Chair", 8.50f, "", "Ikea");
		Product prod3 = new Product("Magazine", 8.50f, "", "Cosmopolitan");
		Product prod4 = new Product("Picture Frame", 8.50f, "", "Antique Store");
		addItem (prod1);
//		addItem (prod2);
//		addItem (prod3);
//		addItem (prod4);
//		Debug.Log (products[0].name);
	}

	void addItem(Product product){
		products.Add (product);
		numOfItems++;
//		GameObject ic = Instantiate(itemCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
//		ItemCell icComp = ic.GetComponent<ItemCell> ();
//
		GameObject itemCell = transform.FindChild("ItemCell ("+numOfItems+")").gameObject; 
		ItemCell itemCellComp = itemCell.GetComponent<ItemCell> ();
//
		itemCellComp.populate (product.name);
//







//		// Position of cell on Canvas (weird math)
//		RectTransform rt = ic.GetComponent<RectTransform> ();
//		rt.sizeDelta = new Vector2( 1.95f, 0.15f);
//		float dY = (float)(1.20f + ((products.Count - 1) * 0.158)); 
//		rt.localPosition = new Vector3 (-0.45f, dY, 1.7f); 
//		ic.transform.parent = transform;
	}
}