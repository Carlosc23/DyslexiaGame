using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Controller : MonoBehaviour {

	[Tooltip("_sceneToLoadOnPlay is the name of the scene that will be loaded when users click play")]
	
	public int TimeLeft=5;
	public int tim;
	public int control=0;
    public static int puntosActuales = 0;
	public int Dificultad;
    public Text recordText;
	public string _sceneToLoadOnPlay = "Mode";
    public string _sceneToLoadOnPlay2 = "Record";
    public string _sceneToLoadOnPlay3 = "Level";
	public string _sceneToLoadOnPlay4 = "Level 2";
    public string[] words = new string[] { "M1 Facil L", "M1 Facil L 1", "M1 Facil L 2", "M1 Facil L 3", "M1 Facil L 4",
    "M1 Facil L 5","M1 Facil L 6","M1 Facil L 7","M1 Facil L 8","M1 Facil L 9","M1 Facil L 10","M1 Facil L 11","M1 Facil L 12",
    "M1 Facil L 13","M1 Facil L 14","M1 Facil L 15","M1 Facil L 16","M1 Facil L 17","M1 Facil L 18","M1 Facil L 19",
    "M1 Facil L 20","M1 Facil L 21","M1 Facil L 22","M1 Facil L 23","M1 Facil L 24","M1 Facil L 25"};
	
	 public string[] difwords = new string[] { "M1 Facil L 26", "M1 Facil L 27", "M1 Facil L 28", "M1 Facil L 29", "M1 Facil L 30",
    "M1 Facil L 31","M1 Facil L 32","M1 Facil L 33","M1 Facil L 34","M1 Facil L 35","M1 Facil L 36","M1 Facil L 37","M1 Facil L 38",
    "M1 Facil L 39","M1 Facil L 40","M1 Facil L 41","M1 Facil L 42","M1 Facil L 43","M1 Facil L 44","M1 Facil L 45"};
	
    public static int cont = 0;
    public static Random rnd = new Random();
    [Tooltip("_webpageURL defines the URL that will be opened when users click on your branding icon")]
	public string _webpageURL = "http://www.alpaca.studio";
	[Tooltip("_soundButtons define the SoundOn[0] and SoundOff[1] Button objects.")]
	public Button[] _soundButtons;
	[Tooltip("_audioClip defines the audio to be played on button click.")]
	public AudioClip _audioClip;
	[Tooltip("_audioSource defines the Audio Source component in this scene.")]
	public AudioSource _audioSource;
	

	
	//The private variable 'scene' defined below is used for example/development purposes.
	//It is used in correlation with the Escape_Menu script to return to last scene on key press.
	UnityEngine.SceneManagement.Scene scene;

	void Awake () {
		tim = TimeLeft;
		if(!PlayerPrefs.HasKey("_Mute")){
			print("Hola");
			print(PlayerPrefs.GetInt("_Mute"));
			PlayerPrefs.SetInt("_Mute", 0);
		}
		
		if (!PlayerPrefs.HasKey("_DIF")){
			PlayerPrefs.SetInt("_DIF",0);

		}
		
		if (!PlayerPrefs.HasKey("_LEV")){
			PlayerPrefs.SetInt("_LEV",0);

		}
        if (!PlayerPrefs.HasKey("_SCORE"))
        {
            PlayerPrefs.SetInt("_SCORE", 0);
        }
        if (!PlayerPrefs.HasKey("_STATE"))
        {
            PlayerPrefs.SetInt("_STATE", 0);
        }
		
		if (!PlayerPrefs.HasKey("_CONT"))
        {
            PlayerPrefs.SetInt("_CONT", 0);
        }
		
        for (int  i = 0;i< 5; i++)
        {
            if (!PlayerPrefs.HasKey("_HighScoreM1E"+i.ToString()))
            {
                PlayerPrefs.SetInt("_HighScoreM1E" + i.ToString(), 0);
            }
            if (!PlayerPrefs.HasKey("_HighScoreM1H" + i.ToString()))
            {
                PlayerPrefs.SetInt("_HighScoreM1H" + i.ToString(), 0);
            }
            if (!PlayerPrefs.HasKey("_HighScoreM2E" + i.ToString()))
            {
                PlayerPrefs.SetInt("_HighScoreM2E" + i.ToString(), 0);
            }
            if (!PlayerPrefs.HasKey("_HighScoreM2H" + i.ToString()))
            {
                PlayerPrefs.SetInt("_HighScoreM2H" + i.ToString(), 0);
            }
        }
		
		
		//print ("jorge");
		//print("Dificultad: " + PlayerPrefs.GetInt("_DIF"));
	
	
		StartCounting();
		
		
		
       
       // recordText.text = "";
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		PlayerPrefs.SetString("_LastScene", scene.name.ToString());
        recordText = GetComponent<Text>();
        //Debug.Log(scene.name);
    }
	
	public void StartCounting(){
		
		
		InvokeRepeating("Count",0,1);
		
	}
	public void palabraIncorrecta1Facil()
    {
        PlayerPrefs.SetInt("_STATE", 2);
		Debug.Log("el estado es incorrecto ..............: " +PlayerPrefs.GetInt("_STATE").ToString());
		//yield return new WaitForSeconds(10);
		Invoke("tiempoincorrecta1",2);
		
        //EnterInventadasFacil1();
    }
	
	
	public void tiempoincorrecta1(){
		EnterInventadasFacil1();
		
	}
	

	
    public void palabraIncorrecta1Dificil()
    {
        PlayerPrefs.SetInt("_STATE", 2);
        EnterInventadasDificil1();
    }
	
	
	
    public void palabraIncorrecta2Facil()
    {
        PlayerPrefs.SetInt("_STATE", 2);
		Invoke("tiempoincorrecta2",2);
        
    }
	
	
	public void tiempoincorrecta2(){
		
		EnterSilabasFacil2();
	}
	
    public void palabraIncorrecta2Dificil()
    {
        PlayerPrefs.SetInt("_STATE", 2);
        EnterSilabasDificil2();
    }
	
	
    public void palabraCorrecta1Facil()
    {
        //PlayerPrefs.SetInt("_STATE", 1);
		cont++;
		cont++;
        EnterInventadasFacil1();
    }
	
	
    public void palabraCorrecta1Dificil()
    {
        PlayerPrefs.SetInt("_STATE", 1);
        EnterInventadasDificil1();
    }
    public void palabraCorrecta2Facil()
    {
        //PlayerPrefs.SetInt("_STATE", 1);
		cont++;
		cont++;
        EnterSilabasFacil2();
    }
    public void palabraCorrecta2Dificil()
    {
        PlayerPrefs.SetInt("_STATE", 1);
        EnterSilabasDificil2();
    }
    public void Count(){
	//TEngo que poner esto dentro del de las dificiles
		if (PlayerPrefs.GetInt("_DIF")==2){
			if(TimeLeft>0){
				TimeLeft--;
				//print (TimeLeft);
			}
			else if (TimeLeft==0){
				print (".,.,.,.,,.,.,.,lost: " + cont.ToString());
                // puntosActuales -= 5;
                PlayerPrefs.SetInt("_STATE", 2);
                if (PlayerPrefs.GetInt("_LEV")==1){
				//EnterInventadasDificil1();	
				EnterInventadasFacil1();
					
				}else if (PlayerPrefs.GetInt("_LEV")==2){
					//EnterSilabasDificil2();
					EnterSilabasFacil2();
				}
				
				

			}
		}
	}
	
	
	public void OpenWebpage () {
		_audioSource.PlayOneShot(_audioClip);
		Application.OpenURL(_webpageURL);
	}
	
	public void PlayGame () {
		PlayerPrefs.SetInt("_DIF",0);
		_audioSource.PlayOneShot(_audioClip);
		PlayerPrefs.SetString("_LastScene", scene.name);
		//Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
		UnityEngine.SceneManagement.SceneManager.LoadScene("Mode");
        //recordText.text = "";
    }
	public void EnterRecords(){
					PlayerPrefs.SetInt("_DIF",0);

        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
//		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay2);
    }
    public void EnterLevelm1(){
        _audioSource.PlayOneShot(_audioClip);
		PlayerPrefs.SetInt("_LEV",1);
        PlayerPrefs.SetInt("_SCORE", 0);
        PlayerPrefs.SetString("_LastScene", scene.name);
		//Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay3);
    }
    public void EnterRecordm1()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("RecordMode1");
    }
    public void EnterRecordm1E()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Record 1");
    }
    public void EnterRecordm1H()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Record 3");
    }
    public void EnterRecordm2()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("RecordMode2");
    }
    public void EnterRecordm2E()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Record 2");
    }
    public void EnterRecordm2H()
    {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
        //Debug.Log("es" + PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Record 4");
    }

    public void EnterLevelm2() {
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetInt("_LEV",2);
        PlayerPrefs.SetInt("_SCORE", 0);
        PlayerPrefs.SetString("_LastScene", scene.name);
		//Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");
    }
	
	//prueba con update
	
	//PARA LOS NIVELES DEL MODO 1
	
	public void EnterInventadasFacil1(){
        if (PlayerPrefs.GetInt("_STATE") == 2)
        {
            puntosActuales -= 5;
            //Debug.Log("puntos actuales: " + puntosActuales.ToString());
            if (cont > 5)
            {
                puntosActuales -= 5;
            }
        }
        //siempre reiniciamos el estado al iniciar en una ueva pantalla
        PlayerPrefs.SetInt("_STATE", 0);
Debug.Log("el estado es : " +PlayerPrefs.GetInt("_STATE").ToString());
		
		//Dificultad=1;
			if (PlayerPrefs.GetInt("_DIF") ==2){
				PlayerPrefs.SetInt("_DIF",2);
			}else{
				
				PlayerPrefs.SetInt("_DIF",1);
			}
		//print ("dificultad"+Dificultad);
		//StartCounting();
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
		//Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        //Debug.Log("Estoy aqui");
        //Debug.Log("InventadasFacil1");
        int r = Random.Range(0, 24);
        
		//prueba para el cont comentado aqui 
		//cont++;
       
            if (PlayerPrefs.GetInt("_DIF")==1){
				cont++;
				cont++;
				cont++;
			Debug.Log("*******************el cont es: " + cont);
			 if (cont <= 16){
                    puntosActuales += 5;
                    PlayerPrefs.SetInt("_SCORE", puntosActuales);
                    Debug.Log("Puntos");
                    Debug.Log(puntosActuales);
                    print(puntosActuales);
               
                UnityEngine.SceneManagement.SceneManager.LoadScene(words[r]);
			//StartCounting();
        }
        else{
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
                puntosActuales -= 5;
              //  Debug.Log("Usted ha obtenido: " + puntosActuales.ToString() + " puntos");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
                //recordText = GetComponent<Text>();
                
               
               // recordText.text = "";
               // recordText.GetComponent<UnityEngine.UI.Text>().text = "Usted ha obtenido: " + puntosActuales.ToString() + " puntos";
            }
        }
		
		if (PlayerPrefs.GetInt("_DIF")==2){
			//cont = (cont-1)/3;
			cont ++;
			
			//cont = cont/3;
			Debug.Log("*******************el cont es: " + cont);
			 if (cont <= 28){
                puntosActuales += 5;
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
                UnityEngine.SceneManagement.SceneManager.LoadScene(words[r]);
				Debug.Log("llegue ------------------------------");
				
			//StartCounting();
			}
        else{
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        }
			
			
		}
		
       
       
    }
	
	public void EnterInventadasDificil1(){
		Dificultad=2;
		PlayerPrefs.SetInt("_DIF",2);
        if (PlayerPrefs.GetInt("_STATE") == 2)
        {
            puntosActuales -= 5;
        }
        PlayerPrefs.SetInt("_STATE", 0);
        //StartCounting();
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
	//	Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
//		print ("Dificil");
  //      Debug.Log("Estoy aquiiiiiiiiiiii");
        int r = Random.Range(0, 24);
        cont++;
		//cont = (cont-1)/3;
		
		
		
        print("Contador: " + cont.ToString());
        if (cont <= 28)
        {
            puntosActuales += 5;
            PlayerPrefs.SetInt("_SCORE", puntosActuales);
            UnityEngine.SceneManagement.SceneManager.LoadScene(words[r]);
        }
        else
        {
            PlayerPrefs.SetInt("_SCORE", puntosActuales);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        }
       
    }
	
	//FIN DE PARA LOS NNIVELES DE MODO 1 
	
	
	//PARA LOS NIVELES DE MODO 2
	
	public void EnterSilabasFacil2(){
        if (PlayerPrefs.GetInt("_STATE") == 2)
        {
            puntosActuales -= 5;
        }
        //siempre reiniciamos el estado al inciiar el nivel 
        PlayerPrefs.SetInt("_STATE", 0);
				Debug.Log("el estado es : " +PlayerPrefs.GetInt("_STATE").ToString());
		
		//Dificultad=1;
			if (PlayerPrefs.GetInt("_DIF") ==2){
				PlayerPrefs.SetInt("_DIF",2);
			}else{
				
				PlayerPrefs.SetInt("_DIF",1);
			}
		print ("dificultad"+Dificultad);
		//StartCounting();
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
	//	Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        //Debug.Log("Estoy aqui");
        //Debug.Log("InventadasFacil1");
        int r = Random.Range(0, 21);
        
        
        if (PlayerPrefs.GetInt("_DIF")==1){
			cont++;
			cont++;
			cont++;
			Debug.Log("*******************el cont es: " + cont);
			 if (cont <= 16){
                    puntosActuales += 5;
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
           //     Debug.Log("Puntos");
             //       Debug.Log(puntosActuales);
                    print(puntosActuales);
               
                UnityEngine.SceneManagement.SceneManager.LoadScene(difwords[r]);
			//StartCounting();
        }
        else{
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");
                recordText = GetComponent<Text>();
                Debug.Log("Usted ha obtenido: " + puntosActuales.ToString() + " puntos");
               // recordText.text = "";
              //  recordText.GetComponent<UnityEngine.UI.Text>().text = "Usted ha obtenido: " + puntosActuales.ToString() + " puntos";
            }
        }
		
		if (PlayerPrefs.GetInt("_DIF")==2){
			//cont = (cont-1)/3;
			cont++;
			
			Debug.Log("*******************el cont es: " + cont);
			 if (cont <= 28){
                puntosActuales += 5;
                PlayerPrefs.SetInt("_SCORE", puntosActuales);
                UnityEngine.SceneManagement.SceneManager.LoadScene(difwords[r]);
			//StartCounting();
        }
        else{
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");
        }
			
			
		}
		
       
       
    }
	
	public void EnterSilabasDificil2(){
        if (PlayerPrefs.GetInt("_STATE") == 2)
        {
            // Debe hacer algo
            puntosActuales -= 5;
        }
        PlayerPrefs.SetInt("_STATE", 0);
        Dificultad =2;
		PlayerPrefs.SetInt("_DIF",2);

		//StartCounting();
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
	//	Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
		//print ("Dificil");
        //Debug.Log("Estoy aqui");
        int r = Random.Range(0, 21);
        cont++;
        print("contador: " + cont.ToString());
        if (cont <= 28)
        {
            puntosActuales += 5;
            PlayerPrefs.SetInt("_SCORE", puntosActuales);
            UnityEngine.SceneManagement.SceneManager.LoadScene(difwords[r]);
        }
        else
        {
            PlayerPrefs.SetInt("_SCORE", puntosActuales);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 3");
        }
       
    }
	
	
	//FIN PARA LOS NIVELES DEL MODO 2
	
	public void BackToMain(){

        if (PlayerPrefs.GetInt("_DIF") == 1)
        {
            for (int i = 0; i < 5; i++)
            {

                int highScore = PlayerPrefs.GetInt("_HighScoreM1E" + i.ToString());

                if (puntosActuales > highScore)
                {
                    int temp = highScore;
                    PlayerPrefs.SetInt("_HighScoreM1E" + i.ToString(), puntosActuales);
                    puntosActuales = temp;
                }
            }
        }
        else if (PlayerPrefs.GetInt("_DIF") == 2)
        {
            for (int i = 0; i < 5; i++)
            {

                int highScore = PlayerPrefs.GetInt("_HighScoreM1H" + i.ToString());

                if (puntosActuales > highScore)
                {
                    int temp = highScore;
                    PlayerPrefs.SetInt("_HighScoreM1H" + i.ToString(), puntosActuales);
                    puntosActuales = temp;
                }
            }
        }

            PlayerPrefs.SetInt("_DIF",0);
       
        PlayerPrefs.SetInt("_SCORE", 0);
      //  Debug.Log("El punteo es :" + PlayerPrefs.GetInt("_SCORE"));
        cont = 0;
		PlayerPrefs.SetInt("_CONT", 0);
        puntosActuales = 0;
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Standalone");
    }
    public void BackToMain2()
    {

        if (PlayerPrefs.GetInt("_DIF") == 1)
        {
            for (int i = 0; i < 5; i++)
            {

                int highScore = PlayerPrefs.GetInt("_HighScoreM2E" + i.ToString());

                if (puntosActuales > highScore)
                {
                    int temp = highScore;
                    PlayerPrefs.SetInt("_HighScoreM2E" + i.ToString(), puntosActuales);
                    puntosActuales = temp;
                }
            }
        }
        else if (PlayerPrefs.GetInt("_DIF") == 2)
        {
            for (int i = 0; i < 5; i++)
            {

                int highScore = PlayerPrefs.GetInt("_HighScoreM2H" + i.ToString());

                if (puntosActuales > highScore)
                {
                    int temp = highScore;
                    PlayerPrefs.SetInt("_HighScoreM2H" + i.ToString(), puntosActuales);
                    puntosActuales = temp;
                }
            }
        }
        PlayerPrefs.SetInt("_DIF", 0);

        PlayerPrefs.SetInt("_SCORE", 0);
      //  Debug.Log("El punteo es :" + PlayerPrefs.GetInt("_SCORE"));
        cont = 0;
		PlayerPrefs.SetInt("_CONT", 0);
        puntosActuales = 0;
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Standalone");
    }
    public void BackToMode(){
					PlayerPrefs.SetInt("_DIF",0);

        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mode");
    }
	
	
	
    public void Mute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = true;
		_soundButtons[1].interactable = false;
		PlayerPrefs.SetInt("_Mute", 1);
		print(PlayerPrefs.GetInt("_Mute"));
	}
	
	public void Unmute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = false;
		_soundButtons[1].interactable = true;
		PlayerPrefs.SetInt("_Mute", 0);
		print(PlayerPrefs.GetInt("_Mute"));
	}
	
	
	public void bmute(){
		
		print(PlayerPrefs.GetInt("_Mute"));
		print ("estoy en bmute");
		if (PlayerPrefs.GetInt("_Mute")==0){
			_audioSource.PlayOneShot(_audioClip);
		
		PlayerPrefs.SetInt("_Mute", 1);
		print(PlayerPrefs.GetInt("_Mute"));
			
		}
		else if (PlayerPrefs.GetInt("_Mute")==1){
			_audioSource.PlayOneShot(_audioClip);
		
		PlayerPrefs.SetInt("_Mute", 0);
		print(PlayerPrefs.GetInt("_Mute"));
			
		}
		
		
	}
	
	public void QuitGame () {
		_audioSource.PlayOneShot(_audioClip);
		#if !UNITY_EDITOR
			Application.Quit();
		#endif
		
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
