﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour {

	public int fishValue;
	
	public GameLogic gameLogic;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick(){
		gameLogic.OnFishClick(fishValue);
	}
}