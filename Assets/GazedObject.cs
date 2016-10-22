using UnityEngine;
using System.Collections;

public class GazedObject : MonoBehaviour {

    public GameObject pointer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGazeOn (float distance)
    {
        Debug.Log("Looking at Blue");
    }
   
    void OnGazeOff (float distance)
    {
        Debug.Log("Not looking at Blue");
    }
}
