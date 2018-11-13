using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public string Name
    {
        get { return "Chest"; }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get { return _Image; }
    }

    public void OnChestClick()
    {
        Debug.Log("Chest opened");
        gameObject.SetActive(false);
    }


    public int max_windows = 16;

    private StatsScript PlayerStats;
    public GameObject player;
    private Collider PlayerCol;


   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats = player.GetComponent<StatsScript>();
        PlayerCol = player.GetComponent<Collider>();
    }
}