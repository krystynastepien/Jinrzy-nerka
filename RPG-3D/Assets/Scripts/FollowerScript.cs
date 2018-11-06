using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerScript : MonoBehaviour {

    Transform Player;

    // Reference to the player's position.
    // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.

    //TODO: usunac distance check!!!!!


    public Vector3 start_follower_position;
    public Vector3 playerPrevPos;

    private Vector3 addVec;

    public Vector3 playerPosMoreLess;

    private string player;
    GameObject Chara;
    Object prefab;

    void Awake()
    {
        player = "asa";
        player = PlayerPrefs.GetString("Character_Selected");
        //chara = GameObject.FindGameObjectWithTag("Player");
        Chara = GameObject.Find(player);
        Player = Chara.transform ;

      
        nav = GetComponent<NavMeshAgent>();

        start_follower_position = this.transform.position;

        nav.speed = 9;

    }



    // Use this for initialization
    void Start()
    {
        playerPrevPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy and the player have health left...
        // if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)

        

        if (Player.transform.position != playerPrevPos)
        {
            // addVec  = new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
            addVec = new Vector3(-2,0,2);
            playerPosMoreLess = Player.transform.position + addVec;
            nav.SetDestination(playerPosMoreLess);
        }


        playerPrevPos = Player.transform.position;






    }
}
