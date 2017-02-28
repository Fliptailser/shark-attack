using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MonoBehaviour {
	
	private int[] valueList = {1,1,1,2,2,2,3,3,4,5,6,7,8,9,11,14};
	
	public GameObject titleCard;
	public GameObject sharkCard;
	public GameObject quintCard;
	public GameObject sharkWinCard;
	public GameObject quintWinCard;
	
	public GameObject sharkSizeText;
	public GameObject quintEnergyText;
	public GameObject quintSellButton;
	
	// add more variables here, and then in Unity put the right object
	// TODO: find out how to just find objects in the scene or whatever
	
	private int sharkSize;
	private int quintEnergy;
	
	private int sharkChoiceIndex;
	private int quintChoiceIndex;
	private int selectedFishPower;
	private int sharkChoicePower;
	private int quintChoicePower;
	
	private bool sell;
	
	private int turn; // 0 for shark, 1 for Quint
	
	
	
	//
	
	// Use this for initialization
	void Start () {
		titleCard.SetActive(true);
		sharkCard.SetActive(false);
		quintCard.SetActive(false);
		sharkWinCard.SetActive(false);
		quintWinCard.SetActive(false);
		sharkSizeText.SetActive(false);
		quintEnergyText.SetActive(false);
		quintSellButton.SetActive(false);
		
		sharkSize = 3;
		quintEnergy = 35;
		
		foreach(Transform child_t in transform){
			child_t.GetComponentInChildren<UnityEngine.UI.Text>().text = "" + valueList[child_t.gameObject.GetComponent<FishScript>().fishIndex];
		}
		
		ShowFish(false);
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
		ShowFish(true);  //<TO DO>show only available fish
		sharkSizeText.GetComponent<UnityEngine.UI.Text>().text  = "Shark size: " + sharkSize;
		sharkSizeText.SetActive(true);
		turn = 0; // shark's turn
	}

	public void OnQuintClick() {
		quintCard.SetActive(false);
		ShowFish(true);  //<TO DO>show only available fish

		quintEnergyText.GetComponent<UnityEngine.UI.Text>().text  = "Quint Energy: " + quintEnergy;
		quintEnergyText.SetActive(true);
		sell = false;
		quintSellButton.SetActive(true);
		turn = 1; // Quint's turn
	}
	
	private void ShowFish(bool visible){
		foreach (Transform child_t in transform){
			child_t.gameObject.SetActive(visible);
		}
	}
	

	
	public void OnFishClick(int fishIndex){
		print (valueList [fishIndex]);
		selectedFishPower = valueList [fishIndex];
		if (turn == 0) { 
			
			if (sharkSize >= selectedFishPower) {
				sharkSizeText.SetActive (false);
				sharkChoiceIndex = fishIndex;
				sharkChoicePower = selectedFishPower;
				ShowFish (false);
				quintCard.SetActive (true);
			}
		}
		if (turn == 1) {
			
			if (sell == false) {
				if (quintEnergy > selectedFishPower) {
					quintEnergyText.SetActive (false);
					quintSellButton.SetActive(false);
					quintChoiceIndex = fishIndex;
					quintChoicePower = selectedFishPower;
					ShowFish (false);
					if (sharkChoiceIndex == quintChoiceIndex) {
						
						if (sharkSize >= quintEnergy) {
							
							sharkWinCard.SetActive (true);
						} else {
							quintWinCard.SetActive (true);
						}
					} else {
						//<TO DO> Set sharkChoiceIndex fish as taken by shark
						//<TO DO> Set quintChoiceIndex fish as taken by quint

						//<TO DO> IF NO MORE FISH LEFT, END GAME

						sharkSize = sharkSize + sharkChoicePower;
						quintEnergy = quintEnergy - quintChoicePower;
						sharkCard.SetActive (true);

					
					}
							
				} 


			} else { //Sell
				quintEnergyText.SetActive (false);
				quintSellButton.SetActive(false);
				quintChoiceIndex = fishIndex;
				quintChoicePower = selectedFishPower;
				ShowFish (false);
			
				//<TO DO> Set sharkChoiceIndex fish as taken by shark
				//<TO DO> Set quintChoiceIndex fish as RELEASED
				sharkSize = sharkSize + sharkChoicePower;
				quintEnergy = quintEnergy + quintChoicePower; //temporary until we fix the line below
				//<TO DO> I don't know how to get this working: quintEnergy = Math.Max(quintEnergy + Math.Floor(quintChoicePower*1.5), 35) ;
				ShowFish (false);
				sharkCard.SetActive (true);
			}

		}
	}
	
	// When they click Quint's sell button
	public void OnSellClick(){
		sell = true;
		//<TO DO> DEACTIVATE REGULAR FISH AND SHOW FISH OWNED BY QUINT
	}
	
	// When they click on the "___ wins" at the end (should either exit or go back to the start)
	public void OnEndGameClick(){
		
	}
}
