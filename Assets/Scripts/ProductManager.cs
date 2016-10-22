using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProductManager : MonoBehaviour {

	private string supercheckoutvr = "localhost:6499/";
	private ServerManager sm;

	void Start(){
		sm = GetComponent<ServerManager> ();
		findAllItems ();
	}

	void createItem () {
		Dictionary<string, string> products = new Dictionary<string, string>();	
	}
	
	void updateItem  (string id) {
		
	}

	void findAllItems() {
		sm.GET(supercheckoutvr + "product/findAll");
	}


}
