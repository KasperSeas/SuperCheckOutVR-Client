using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductManager : MonoBehaviour {

	private string supercheckoutvr = "localhost:6499";
	// Use this for initialization
	void createItem () {
		Dictionary<string, string> products = new Dictionary<string, string>();	
	}
	
	void updateItem  () {
	
	}

	void findAllItems() {
		ServerManager.GET(supercheckoutvr + "product/findAll");
	}


}
