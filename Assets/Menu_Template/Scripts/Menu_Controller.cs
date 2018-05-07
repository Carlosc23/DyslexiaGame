using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Controller : MonoBehaviour {

	[Tooltip("_sceneToLoadOnPlay is the name of the scene that will be loaded when users click play")]
	public string _sceneToLoadOnPlay = "Mode";
    public string _sceneToLoadOnPlay2 = "Record";
    public string _sceneToLoadOnPlay3 = "Level";
	public string _sceneToLoadOnPlay4 = "Level 2";
    public string[] words = new string[] { "M1 Facil L", "M1 Facil L 1", "M1 Facil L 2", "M1 Facil L 3", "M1 Facil L 4",
    "M1 Facil L 5","M1 Facil L 6","M1 Facil L 7","M1 Facil L 8","M1 Facil L 9","M1 Facil L 10","M1 Facil L 11","M1 Facil L 12",
    "M1 Facil L 13","M1 Facil L 14","M1 Facil L 15","M1 Facil L 16","M1 Facil L 17","M1 Facil L 18","M1 Facil L 19",
    "M1 Facil L 20","M1 Facil L 21","M1 Facil L 22","M1 Facil L 23","M1 Facil L 24","M1 Facil L 25"};
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
		if(!PlayerPrefs.HasKey("_Mute")){
			PlayerPrefs.SetInt("_Mute", 0);
		}
		
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
		PlayerPrefs.SetString("_LastScene", scene.name.ToString()); 
		//Debug.Log(scene.name);
	}
	
	public void OpenWebpage () {
		_audioSource.PlayOneShot(_audioClip);
		Application.OpenURL(_webpageURL);
	}
	
	public void PlayGame () {
		_audioSource.PlayOneShot(_audioClip);
		PlayerPrefs.SetString("_LastScene", scene.name);
		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
		UnityEngine.SceneManagement.SceneManager.LoadScene("Mode");
	}
	public void EnterRecords(){
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay2);
    }
    public void EnterLevelm1(){
        _audioSource.PlayOneShot(_audioClip);
		
        PlayerPrefs.SetString("_LastScene", scene.name);
		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneToLoadOnPlay3);
    }
	
	public void EnterLevelm2(){
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");
    }
	
	public void EnterInventadasFacil1(){
        _audioSource.PlayOneShot(_audioClip);
        PlayerPrefs.SetString("_LastScene", scene.name);
		Debug.Log("es" +PlayerPrefs.GetString("_LastScene"));
        Debug.Log("Estoy aqui");
        int r = Random.Range(0, 24);
        cont++;
        if (cont <= 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(words[r]);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        }
       
    }
	
	
	
	public void BackToMain(){
        cont = 0;
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Standalone");
    }
	
	public void BackToMode(){
        _audioSource.PlayOneShot(_audioClip);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mode");
    }
	
	
	
    public void Mute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = true;
		_soundButtons[1].interactable = false;
		PlayerPrefs.SetInt("_Mute", 1);
	}
	
	public void Unmute () {
		_audioSource.PlayOneShot(_audioClip);
		_soundButtons[0].interactable = false;
		_soundButtons[1].interactable = true;
		PlayerPrefs.SetInt("_Mute", 0);
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
