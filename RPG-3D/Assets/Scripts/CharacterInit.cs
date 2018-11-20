using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInit : MonoBehaviour {

    private string player;
    private string follower;

    GameObject Chara;
    GameObject Followr;

    Object prefab;

    // Use this for initialization
    void Start () {

        
            player = "asa";
            follower = "hato";
        
            player = PlayerPrefs.GetString("Character_Selected");
            follower = PlayerPrefs.GetString("Character_Follower");

        //przypisanie obiektow poprzez nazwe  
     //   Debug.Log("1:   player to: " + player + ",  a follower to: " + follower);
        Chara = GameObject.Find(player);
        Followr = GameObject.Find(follower);

      //  Debug.Log("2:   player to: " + Chara.name + ",  a follower to: " + Followr.name);


        Chara.tag = "Player";
        Followr.tag = "Follower";

       // Followr.AddComponent<FollowerScript>();
       // Followr.GetComponent<WSAD8dir>().enabled = false;

       // Chara.AddComponent<WSAD8dir>();
       // Chara.GetComponent<FollowerScript2>().enabled = false;


         Followr.SetActive(false);

     //   Debug.Log("3:   gracz to: " + PlayerPrefs.GetString("Character_Selected") + ",  a follower to: " + PlayerPrefs.GetString("Character_Follower"));
    }
	
	// Update is called once per frame
	void Update () {
      //  Debug.Log("gracz to: " + PlayerPrefs.GetString("Character_Selected") + ",  a follower to: " + PlayerPrefs.GetString("Character_Follower"));
    }
}
