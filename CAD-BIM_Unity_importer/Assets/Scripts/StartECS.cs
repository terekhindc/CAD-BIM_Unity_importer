using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartECS : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Spawner1")
        {
            BigCubeSpawner.InitalizeWithScene();
        } else if (scene.name == "Spawner2")
        {
            CubeSpawner2.InitalizeWithScene();
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
