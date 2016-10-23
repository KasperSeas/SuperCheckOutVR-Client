using UnityEngine;
using System.Collections;

public class Product : Object {
	public string name;
	public float price;
	public string description;
	public string brand;

	public Product(string name, float price, string description, string brand){
		this.name = name;
		this.price = price;
		this.description = description;
		this.brand = brand;
	}

}
