using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour {

    public float aid = 20;

    private StatsScript PlayerStats;
    public GameObject player;
    private Collider PlayerCol;
    // Use this for initialization
    void Start () {
        PlayerStats = player.GetComponent<StatsScript>();
        PlayerCol = player.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerStats.health < 1000)
            {
                PlayerStats.health = PlayerStats.health + aid;
                if (PlayerStats.health > 1000)
                {
                    PlayerStats.health = 1000;
                }
            }

            DestroyObject(this.gameObject);
        }
        
     
    }
}
