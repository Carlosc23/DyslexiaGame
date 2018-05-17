using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	Image fillImg;
	float TimeAmt = 5; 
	float time; 

	// Use this for initialization
	void Start () {
		
		fillImg = this.GetComponent<Image>();
		time = TimeAmt;
		
		//prueba para las dificultades
		
		if (PlayerPrefs.GetInt("_DIF") ==2){
			fillImg.enabled = true;
		}else{
			
			fillImg.enabled = false;
			
		}
		
		
			
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (time > 0 ){
			
			time -= Time.deltaTime;
			fillImg.fillAmount =  time / TimeAmt; //ir contando el tiempo 
			
			
		}
	}
}
