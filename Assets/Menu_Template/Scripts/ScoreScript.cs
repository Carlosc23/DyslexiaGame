using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    Text txt;
    public string a = "";
    // Use this for initialization
    void Start () {
        txt = this.GetComponent<Text>();
        a = "Su punteo es: " + PlayerPrefs.GetInt("_SCORE").ToString();
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = a;
       
    }
}
