using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductManager : MonoBehaviour {

	private string supercheckoutvr = "localhost:6499/";
	private ServerManager sm;

	void Start(){
		sm = GetComponent<ServerManager> ();
//		findAllItems ();
		Product prod = new Product("Blue Paint", 5.0f);


		createItem(prod);

	}

	void createItem (Product product) {
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict.Add ("name", product.name);
		dict.Add ("price", product.price.ToString());
		sm.POST (supercheckoutvr + "product/create", dict);
	}
	
	void updateItem  (string id, Product product) {
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict.Add ("name", product.name);
		dict.Add ("price", product.price.ToString());
//		sm.POST (supercheckoutvr + "product/findAll", dict);
	}

	void findAllItems() {
		sm.GET(supercheckoutvr + "product/findAll");
	}


}
