using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerManager : MonoBehaviour {

	private string results;
	private string supercheckoutvr = "localhost:6499/";

	public delegate void OnCompleteDelegate();
	public void OnComplete(string results)
	{
		JSONObject json = new JSONObject (results);
		Debug.Log (json);
	}

	void Start(){
		

//		Dictionary<string, string> products = new Dictionary<string, string>();

//		products.Add("name", "Coffee Mug");
//		products.Add("price", "5.29");

//		POST (supercheckoutvr + "product/create", products);

//		GET(supercheckoutvr + "product/findAll");
	}

	public WWW GET(string url) {
		

		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
		return www;
	}

	public WWW POST(string url, Dictionary<string,string> post) {
		WWWForm form = new WWWForm();

		foreach(KeyValuePair<string,string> post_arg in post) {
			form.AddField(post_arg.Key, post_arg.Value);
		}

		WWW www = new WWW(url, form);

		StartCoroutine(WaitForRequest(www));
		return www;
	}

	private IEnumerator WaitForRequest(WWW www) {
		yield return www;
		// check for errors
		if (www.error == null) {
			results = www.text;
			OnComplete(results);
		} else {
			Debug.Log (www.error);
		}
	}


}
