using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductManager : MonoBehaviour {

	private string supercheckoutvr = "localhost:6499/";
	private ServerManager sm;

	void Start(){
		sm = GetComponent<ServerManager> ();
//		findAllItems ();
		Product prod = new Product("Blue Paint", 8.0f);
//		blue paint id: 580bf2867ca1704f69b6432a

//		createItem(prod);
		updateItem("580bf2867ca1704f69b6432a", prod);

	}

	void createItem (Product product) {
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict.Add ("name", product.name);
		dict.Add ("price", product.price.ToString());
		sm.POST (supercheckoutvr+"product/create", dict);
	}
	
	void updateItem  (string id, Product product) {
		Dictionary<string, string> dict = new Dictionary<string, string>();
		dict.Add ("name", product.name);
		dict.Add ("price", product.price.ToString());
		sm.POST (supercheckoutvr+"product/update?_id="+id, dict);
	}

	void findAllItems() {
		sm.GET(supercheckoutvr+"product/findAll");
	}


}
