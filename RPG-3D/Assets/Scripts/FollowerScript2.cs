using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript2 : MonoBehaviour {

    public Transform target; //the enemy's target
    private float moveSpeed = 5; //move speed
    private float rotationSpeed = 3; //speed of turning


    Transform myTransform; //current transform data of this enemy


    private string player;
    GameObject Chara;
    Object prefab;

    void Start()
    {

        player = "asa";
        player = PlayerPrefs.GetString("Character_Selected");
        //chara = GameObject.FindGameObjectWithTag("Player");
        Chara = GameObject.Find(player);
        target = Chara.transform;
        myTransform = transform; //cache transform data for easy access/preformance
    }


    void Update()
    {
        //rotate to look at the player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
        Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);


        //move towards the player
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

    }
}
