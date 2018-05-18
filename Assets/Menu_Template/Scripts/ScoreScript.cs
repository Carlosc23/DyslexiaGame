using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    Text txt;
	// Use this for initialization
	void Start () {
        txt = this.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "Su punteo es: " + PlayerPrefs.GetInt("_SCORE").ToString();
	}
}
