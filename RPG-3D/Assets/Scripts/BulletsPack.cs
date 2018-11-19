using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPack : MonoBehaviour, IInventoryItem
{

    public string Name   //interface field, zwraca nazwe obiektu
    {
        get { return "Bullets Box"; }   
    }

    public Sprite _Image = null;

    public Sprite Image     //interface field
    { 
        get { return _Image; }
    }

    public void OnPickup()   // interface field
    {
        Debug.Log("bullets picked and deactivated");
        gameObject.SetActive(false);
    }

}
