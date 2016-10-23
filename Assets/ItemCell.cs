using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour {

	void Start () {
//		GameObject childGO = transform.FindChild("Name").gameObject;
//		Text name = childGO.GetComponent<Text> ();
//		name.text = "moo";
//		Debug.Log (name.text);
	}

	public void populate(string name){
		GameObject child = transform.FindChild("Name").gameObject;
		Text childName = child.GetComponent<Text> ();
		childName.text = name;
	}

}
