using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScript4 : MonoBehaviour {
    Text txt;
    // Use this for initialization
    void Start()
    {
        txt = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string puntaje = "";
        int temp = 0;
        for (int i = 0; i < 5; i++)
        {

            int highScore = PlayerPrefs.GetInt("_HighScoreM2H" + i.ToString());
            temp = i + 1;
            puntaje += temp.ToString() + ". " + highScore.ToString() + " puntos \n";
        }
        txt.text = puntaje;
    }
}
