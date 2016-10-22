using UnityEngine;
using System.Collections;

public class ServerManager : MonoBehaviour {

	private string results;

	public delegate void OnCompleteDelegate();
	public void OnComplete(string results)
	{
		Debug.Log (results);
		JSONObject 
	}

	void Start(){
		GET ("https://supercheckoutvr.herokuapp.com/product/findAll");
	}

	public WWW GET(string url) {
		

		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
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
