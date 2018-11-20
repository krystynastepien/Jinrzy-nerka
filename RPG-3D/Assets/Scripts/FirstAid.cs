using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase {    //implementuje IInventoryItem wiec potrzebuje Name, Image i onPickup

    public override string Name   //interface field
    {
        get { return "FirstAidKit"; }
    }

    
    //public Sprite _Image = null;

    public override Sprite Image   //interface field
    {
        get { return _Image; }
    }
 /*



    public void OnPickup()   //interface field
    {
        Debug.Log("Kit picked and deactivated");
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }
    */

    //--------------------------------------------

    public float aid = 20;
    private StatsScript PlayerStats;
    public GameObject player;
    private Collider PlayerCol;

    /*
    public virtual void AddHealth()
    {
        if (PlayerStats.health < 1000)
        {
            PlayerStats.health = PlayerStats.health + aid;
            if (PlayerStats.health > 1000)
            {
                PlayerStats.health = 1000;
            }
        }
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
           // DestroyObject(this.gameObject);
        }
    } */


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats = player.GetComponent<StatsScript>();
        PlayerCol = player.GetComponent<Collider>();
    }
    
}
