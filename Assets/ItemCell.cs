using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour {

	Image brandImage;
	Text brandLabel;
	Text nameLabel;
	Text quantityLabel;
	Text priceLabel;
	Text totalLabel;

	void Start () {
		brandImage = transform.FindChild("Image").gameObject.GetComponent<Image>();
		brandLabel = transform.FindChild("Brand").gameObject.GetComponent<Text>();
		nameLabel = transform.FindChild("Name").gameObject.GetComponent<Text>();
		quantityLabel = transform.FindChild("Quantity").gameObject.GetComponent<Text>();
		priceLabel = transform.FindChild("Price").gameObject.GetComponent<Text>();
		totalLabel = transform.FindChild("Total").gameObject.GetComponent<Text>();
		transform.gameObject.SetActive (false);
	}

	public void populate(Product product){
		brandLabel.text = product.brand;
		nameLabel.text = product.name;
		quantityLabel.text = product.quantity.ToString ();
		string price = "$" + string.Format("{0:0.00}", product.price);
		priceLabel.text = price;
		string total = "$" + string.Format("{0:0.00}", product.price * product.quantity);
		totalLabel.text = total;
		transform.gameObject.SetActive (true);
	}
}
