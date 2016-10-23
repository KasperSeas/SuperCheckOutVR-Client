using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShoppingCart : MonoBehaviour {

	public List<Product> products;
	public GameObject itemCell;
	public int numOfItems;

	Product prod1 = new Product("Sofa", 145.34f, "", "Ikea");
	Product prod2 = new Product("Chair", 8.50f, "", "Ikea");
	Product prod3 = new Product("Magazine", 8.50f, "", "Cosmopolitan");
	Product prod4 = new Product("Picture Frame", 8.50f, "", "Amazon");

	Text grandTotalLabel;

	void Start(){
		products = new List<Product> ();
		numOfItems = 0;
		grandTotalLabel = transform.FindChild ("GrandTotal").gameObject.GetComponent <Text> ();

		//addItem (prod1);
		//addItem (prod1);
		//addItem (prod3);
		//addItem (prod4);
		//updateTable ();

		//Invoke ("test1", 2);
		//Invoke ("test2", 4);
		//Invoke ("test3", 6);
	}

	public void removeItem(Product product) {
		for (var i = 0; i < products.Count; i++) {
			if (products [i].name == product.name) {
				if (product.quantity > 1) {
					product.quantity -= 1;
				} else {
					products.RemoveAt (i);
				}
				return;
			}
		}
        updateTable();
	}

	public void addItem(Product product){
		bool duplicate = false;
		for (var i = 0; i < products.Count; i++) { if (products[i].brand == product.brand) { products[i].quantity += 1; duplicate = true; } }
		if (!duplicate) { products.Add (product); }
        updateTable();
	}

	public void updateTable() {
		grandTotalLabel.text = "";
		float grandTotal = 0.0f;
		for (var i = 0; i < 4; i++) {
			int index = i + 1;
			GameObject itemCell = transform.FindChild ("ItemCell (" + index + ")").gameObject; 
			itemCell.SetActive (false);
		}
		for (var i = 0; i < products.Count; i++) {
			int index = i + 1;
			GameObject itemCell = transform.FindChild("ItemCell (" + index + ")").gameObject; 
			ItemCell itemCellComp = itemCell.GetComponent<ItemCell> ();
			itemCellComp.populate (products[i]);
			grandTotal += products [i].price * products [i].quantity;
		}
		string total = "$" + string.Format("{0:0.00}", grandTotal);    
		grandTotalLabel.text = total;
	}

	public void test1() {
		removeItem (prod1);
		updateTable ();
	}

	public void test2() {
		addItem (prod2);
		addItem (prod2);
		addItem (prod2);
		removeItem (prod3);
		updateTable ();
	}

	public void test3() {
		addItem (prod1);
		addItem (prod2);
		addItem (prod3);
		addItem (prod4);
		updateTable ();
	}
}
