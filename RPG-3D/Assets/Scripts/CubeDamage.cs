﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDamage : MonoBehaviour {

    private float timer;
    public int seconds;

    public float damage = 1;

    private StatsScript PlayerStats;
    public GameObject player;
    private Collider PlayerCol;


    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.tag=="Player")
        {
            (PlayerStats.health) -= damage * seconds/120 ;
        }
    }


    // Use this for initialization
    void Start () {
        PlayerStats = player.GetComponent<StatsScript>();
        PlayerCol = player.GetComponent<Collider>();
       
    }
	


	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        timer = timer % 60;
        seconds = Mathf.RoundToInt(timer);
    }
}
