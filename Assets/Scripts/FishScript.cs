using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

	public int fishIndex;
	
	// This state tells who has this Fish right now
	public enum FishStates { None, Shark, Quint };
	
	public GameLogic gameLogic;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick(){
		gameLogic.OnFishClick(fishIndex);
	}
}
