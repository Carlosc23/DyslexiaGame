using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bad_Controllerr : MonoBehaviour {


	Image fillImg;

	// Use this for initialization
	void Start () {
		
		fillImg = this.GetComponent<Image>();
		//Debug.Log("logre llegar hasta aca*********************************");
		if (PlayerPrefs.GetInt("_STATE") ==2){
			fillImg.enabled = true;
		}else{
			
			fillImg.enabled = false;
			
		}
		
		
			
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("logre llegar hasta aca*********************************UPDATE" + PlayerPrefs.GetInt("_STATE").ToString());
		
		if (PlayerPrefs.GetInt("_STATE") ==2){
			fillImg.enabled = true;
			Debug.Log("mala");	
		}else{
			
			fillImg.enabled = false;
			
		}
		
		
	}
}
