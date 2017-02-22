using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
	
	public GameObject titleCard;
	public GameObject sharkCard;
	public GameObject quintCard;
	public GameObject fishPool;

	// Use this for initialization
	void Start () {
		titleCard.SetActive(true);
		sharkCard.SetActive(false);
		quintCard.SetActive(false);
		fishPool.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnTitleClick() {
		titleCard.SetActive(false);
		sharkCard.SetActive(true);
	}
	
	public void OnSharkClick() {
		sharkCard.SetActive(false);
		fishPool.SetActive(true);
	}
	
	public void OnQuintClick() {
	
	}
	
	public void OnFishClick(int fishValue){
		print(fishValue);
	}
}
