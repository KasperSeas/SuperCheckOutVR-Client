using UnityEngine;
using System.Collections;

public class Product : Object {
	public string name;
	public float price;
	public string description;

	public Product(string name, float price, string description){
		this.name = name;
		this.price = price;
		this.description = description;
	}

}
