using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMangler : MonoBehaviour {
	
	//static SceneManager Instance;

	// Use this for initialization
	//void Start () {
	//	if (Instance != null) {
	//		GameObject.Destroy (gameObject);

	//	} else {
	//		GameObject.DontDestroyOnLoad (gameObject);
	//		Instance = this;
	//	}
	//}

	void Update ()
	{
		// wait 3 seconds or move to main menu if touched
		while (Time.realtimeSinceStartup < 3)
		{
			if (Input.touchSupported )
			{
				if (Input.GetTouch(0).tapCount > 0)
				{
					Application.LoadLevel ("Main Menu");
				}
			}
			else {
				if (Input.GetKeyDown ("space")) {
					Application.LoadLevel ("Main Menu");
					//Application.LoadLevel("Title Screen");
				}
			}
		}

		// times up, go to main menu
		//if (Scene.name == "Title Screen") {
			Application.LoadLevel ("Main Menu");
		//}

	}
}

