using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

    public Button bt_load, bt_quit;

    // Use this for initialization
    void Start () {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        bt_load.onClick.AddListener(QuitGame);
        bt_load.onClick.AddListener(delegate { LoadLevel("PrototypeMainMap1_Scene"); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(string scene_name){
        SceneManager.LoadScene(scene_name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
