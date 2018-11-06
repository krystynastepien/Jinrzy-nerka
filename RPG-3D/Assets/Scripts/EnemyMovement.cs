using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    Transform Player;
    StatsScript StatsScr;
    // Reference to the player's position.
   // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    public Vector3 distance;
    public float distCheck = 40;

    public Vector3 start_enemy_position;
    public Vector3 playerPosChanged;


    private string player;
    GameObject Chara;
    Object prefab;

    void Awake()
    {
        player = "asa";
        player = PlayerPrefs.GetString("Character_Selected");
        //chara = GameObject.FindGameObjectWithTag("Player");
        Chara = GameObject.Find(player);
        Player = Chara.transform;

        // Set up the references.
       // player = GameObject.FindGameObjectWithTag("Player").transform;
       // StatsScr = player.GetComponent<StatsScript>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();

        start_enemy_position = this.transform.position;
        
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // If the enemy and the player have health left...
        // if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)

         playerPosChanged = Player.transform.position + new Vector3(1,0,1);

        distance.x = Player.transform.position.x - this.transform.position.x;
        distance.x = Mathf.Abs(distance.x);

        distance.z = Player.transform.position.z - this.transform.position.z;
        distance.z = Mathf.Abs(distance.z);

        nav.SetDestination(Player.position);

        /*
        if ( StatsScr.health > 0)
            {
            if (distance.x <= distCheck || distance.z <= distCheck)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(Player.position);
            }
            else if (distance.x > distCheck || distance.z > distCheck)
            {
                // ... disable the nav mesh agent.
                nav.SetDestination(start_enemy_position);
            }

        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        } */
    }  
}
