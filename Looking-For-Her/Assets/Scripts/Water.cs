using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    Collider2D player_collider;


    // Use this for initialization
    void Start () {
        player_collider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D player_col)
    {
        if (player_col.gameObject.tag=="Player")
        {
            PlayerPrefs.SetInt("isDead", 1);
            Debug.Log("Game Over");
            PlayerPrefs.SetInt("current_hearts",0);


        }
    }
}
