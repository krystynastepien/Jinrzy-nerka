using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character { //dziedziczy z Charcter. Player to także Character

    private GameObject player;
    private Rigidbody2D rigidBody2D;
    private float speed = 5;  //protected nie pokazuje w inspektorze ale pozwala innym klasom dziedziczącym uzywac tej zmiennej
    //private Vector2 direction;
    Vector2 move;
    private SpriteRenderer playerSpriteRenderer;
    // Use this for initialization
    void Start () {
       // direction = Vector2.up;
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody2D = player.GetComponent<Rigidbody2D>();
        rigidBody2D.gravityScale = 0;
        move = new Vector2(0,0);

    }

    // Update is called once per frame
    // protected override void Update () { //override nadpisuje funkcje jako tą z klady Character
    new void Update() { 
        GetWSAD();
        Move();
        // base.Update(); //zapuszcza metode Update z Character class (base)
	}


    public void Move()
    {
        //transform.Translate(Vector2.right);   // porusza sie sam w prawo super szybko
        //transform.Translate(Vector2.right*speed*Time.deltaTime);  //porusza sie sam w prawo wolniej  wolniej
         // transform.Translate(direction * speed * Time.deltaTime); //direction zmienia sie z wcisnieciem klawisza w GetWSAD

        //dzieki temu nie odbija sie jak glupi od scian
        rigidBody2D.MovePosition(new Vector2((player.transform.position.x + move.x * speed * Time.deltaTime), (player.transform.position.y + move.y * speed * Time.deltaTime)));
    }


    public void GetWSAD()
    {
        //direction = Vector2.zero;  //zeruje zmienna direction po każdej pętli if 
                                   //(żeby sie nie poruszakl szybciej i szybciej tylko ciagle w tej samej predkosci)
        move = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W)) 
        {
          //  direction += Vector2.up;
            move += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
           // direction += Vector2.down;
            move += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
          //direction += Vector2.right;
            playerSpriteRenderer.flipX = false; // flip the sprite
            move += new Vector2(1, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
          //  direction += Vector2.left;
            playerSpriteRenderer.flipX = true; // flip the sprite
            move += new Vector2(-1, 0);
        }
    }
}
