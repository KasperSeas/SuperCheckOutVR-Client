using UnityEngine;
using System.Collections;

public class Product : Object {
	public string name;
	public float price;

	public Product(string name, float price){
		this.name = name;
		this.price = price;
	}

}
