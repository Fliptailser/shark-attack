using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private int quintChoideIndex;
	
	private bool quintSelling;
	
	private int turnNumber;
	
	
	
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
		ShowFish(true);
		sharkSizeText.GetComponent<UnityEngine.UI.Text>().text  = "Shark size: " + sharkSize;
		sharkSizeText.SetActive(true);
	}
	
	private void ShowFish(bool visible){
		foreach (Transform child_t in transform){
			child_t.gameObject.SetActive(visible);
		}
	}
	
	public void OnQuintClick() {
	
	}
	
	public void OnFishClick(int fishIndex){
		print(valueList[fishIndex]);
	}
	
	// When they click Quint's sell button
	public void OnSellClick(){
		
	}
	
	// When they click on the "___ wins" at the end (should either exit or go back to the start)
	public void OnEndGameClick(){
		
	}
}
