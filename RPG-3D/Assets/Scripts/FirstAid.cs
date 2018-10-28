using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour, IInventoryItem {

    public string Name
    {
        get { return "FirstAidKit"; }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get { return _Image; }
    }

    public void OnPickup()
    {
        Debug.Log("Kit picked and deactivated");
        gameObject.SetActive(false);
    }

    

    public float aid = 20;
    private StatsScript PlayerStats;
    public GameObject player;
    private Collider PlayerCol;


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
           // DestroyObject(this.gameObject);
        }
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats = player.GetComponent<StatsScript>();
        PlayerCol = player.GetComponent<Collider>();
    }
    
}
