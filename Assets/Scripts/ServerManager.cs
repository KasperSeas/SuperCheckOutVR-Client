﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ServerManager : MonoBehaviour {

	private string results;
    public JSONObject payment;

	public delegate void OnCompleteDelegate();
	public void OnComplete(string results) {
		payment = new JSONObject (results);
        Debug.Log(results);
        string payment_id = payment.ToDictionary()["payment_id"].ToString();
        string status = payment.ToDictionary()["status"].ToString();
        Debug.Log(payment_id);
        Debug.Log(status);
        GameObject.Find("ThankYouCanvas").GetComponent<ThankYou>().updateData(payment_id, status);
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
