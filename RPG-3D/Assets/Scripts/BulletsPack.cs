using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPack : MonoBehaviour, IInventoryItem
{

    public string Name
    {
        get { return "Bullets Box"; }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get { return _Image; }
    }

    public void OnPickup()
    {
        Debug.Log("bullets picked and deactivated");
        gameObject.SetActive(false);
    }

}
