using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	Scene titleScreen;

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting ChangeScene");
		titleScreen = SceneManager.GetActiveScene ();
		ManageLoadingInitialScene ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ManageLoadingInitialScene() {
		Debug.Log ("Entered: ManageLoadingInitialScene");
		// wait 3 seconds or move to main menu if touched
		while (Time.realtimeSinceStartup < 3)
		{
			if (Input.touchSupported )
			{
				if (Input.GetTouch(0).tapCount > 0)
				{
					Debug.Log ("Touched: Changing to main screen");
					SceneManager.LoadScene ("Main Menu");
				}
			}
			else {
				if (Input.GetKeyDown ("space")) {
					Debug.Log ("Spaced: Changing to main screen");
					SceneManager.LoadScene ("Main Menu");
					//Application.LoadLevel("Title Screen");
				}
			}
		}
		if (SceneManager.GetActiveScene() == titleScreen) {
			Debug.Log ("Timed out: Changing to main screen");
			SceneManager.LoadScene ("Main Menu");
		}
	}
}
