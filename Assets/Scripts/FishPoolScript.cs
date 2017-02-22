using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPoolScript : MonoBehaviour {

	private int[] valueList = {1,1,1,2,2,2,3,3,4,5,6,7,8,9,11,14};

	// Use this for initialization
	void Start () {
		
		foreach (Transform child_t in transform){
			// Transform text = child_t.Find("Text");
			// text.SetText("A");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
