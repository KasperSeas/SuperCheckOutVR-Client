using UnityEngine;
using System.Collections;

public class ViewObject : SteamVR_LaserPointer {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPointerIn(PointerEventArgs e)
    {
        Debug.Log("Pointed at");
    }

    public void OnPointerOut(PointerEventArgs e)
    {
        Debug.Log("Not Pointed at");
    }
}
