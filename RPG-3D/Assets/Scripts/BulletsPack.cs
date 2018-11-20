using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPack : InventoryItemBase
{

    public override string Name   //interface field, zwraca nazwe obiektu
    {
        get { return "Bullets Box"; }   
    }
    /*
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

    public virtual OnDrop()
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
}
