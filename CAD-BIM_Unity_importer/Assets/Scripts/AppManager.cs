using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
	}

    public void StartLoadSCene (string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
