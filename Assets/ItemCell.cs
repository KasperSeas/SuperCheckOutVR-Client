using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour {

	public string name; 

	void Start () {
		GameObject childGO = transform.FindChild("Name").gameObject;
		Text name = childGO.GetComponent<Text> ();
		name.text = "moo";
		Debug.Log (name.text);
	}
	
}
