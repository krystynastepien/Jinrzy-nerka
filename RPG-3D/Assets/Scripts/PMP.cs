using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMP : MonoBehaviour {

    public float timer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 1 * Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
	}

    public void DestroyPMP()
    {
        Destroy(this.gameObject);
    }
}
