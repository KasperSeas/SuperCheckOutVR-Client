using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour {

	private string supercheckoutvr = "localhost:6499/";
	private ServerManager sm;

	void Start(){
		sm = GetComponent<ServerManager> ();
//		findAllItems ();
		Product prod = new Product("Blue Paint", 8.0f, "", "");
//		createItem(prod);
//		updateItem("580bf8557ca1704f69b6432d", prod);
//		findItem("580bf2867ca1704f69b6432a");
//		destroyItem("580bf8557ca1704f69b6432d");
		// findAllItems();
	}

    public void ENDIT()
    {
        ShoppingCart sc = GameObject.Find("ShoppingCartCanvas").GetComponent<ShoppingCart>();
        string total = sc.transform.FindChild("GrandTotal").gameObject.GetComponent<Text>().text;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("customer_id", "580bf54f01900b53257573b2");
        dict.Add("price", total);
        sm.POST(supercheckoutvr + "payment/create", dict);
    }

	void createItem (Product product) {
        // Dictionary<string, string> dict = new Dictionary<string, string>();
		// sm.POST (supercheckoutvr+"product/create", dict);
	}

	void findItem (string id) {
		sm.GET(supercheckoutvr+"product/findOne?_id="+id);	
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

	void destroyItem(string id) {
		sm.GET (supercheckoutvr+"product/destroy?_id="+id);
	}


}
