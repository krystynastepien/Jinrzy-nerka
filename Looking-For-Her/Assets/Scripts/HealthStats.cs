using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthStats : MonoBehaviour {

    private Image[] heart_images; //serca -> nie mylić ze sprite, Image to typ obiektu
    /// <summary>
    /// Make sure the sprite is inside a folder called "Resources", it doesn't matter where this folder is, as long as it's named that way. 
    /// If you have nested folders inside the "Resources" folder, you need to adress the sprite using the folder, 
    /// e.g. Resources.Load<Sprite>("folderInsideresourcesfolder/char1_0");
    /// DLA  private Sprite empty_heart, full_heart;
    /// </summary>
    public Sprite empty_heart;
    public Sprite full_heart;
    private Sprite[] heart_sprites = new Sprite[2];
    private int max_hearts = 9, changed_hearts;
    protected int current_hearts; /// !!!!!!!!!!!!!!!!!!!!! TODO zmienic na PRIVATE
    int h = 0; // licznik serc -> Start();
    
    bool isDead;

    // Use this for initialization
    void Start () {
        isDead = false;
        // hp_bar = GameObject.FindGameObjectWithTag("HealthBar");
        current_hearts = max_hearts; 
        PlayerPrefs.SetInt("current_hearts", current_hearts);
        PlayerPrefs.SetInt("isDead", 0);
        heart_images = GetComponentsInChildren<Image>();
        heart_sprites[0] = empty_heart;
        heart_sprites[1] = full_heart;



        changed_hearts = current_hearts;
       

        foreach (Image child in heart_images) // przypisanie pełnych serc i wstawienie 9 serc w tabele 0-8 serc
        {
            child.sprite = full_heart;
            heart_images[h] = child;
            h++;
        }
    }
	
	// Update is called once per frame
	void Update () {

       Debug.Log( PlayerPrefs.GetInt("current_hearts"));

        if (PlayerPrefs.GetInt("isDead")==1)
        {
            // WaitAndGameOver(5); //czeka 5 sekund?
            SceneManager.LoadScene("PrototypeGameOver_Scene");
        }

       // Debug.Log(heart_images.Length);  // -> 9
        if (changed_hearts < current_hearts)
        { 
            FillTheHearts();
            
        }else if (changed_hearts > current_hearts)
        {
            EmptyTheHearts();
        }
	}

    public void EmptyTheHearts()
    {
        for (int i = 8; i >= current_hearts; i--)
        {
            heart_images[i].sprite = heart_sprites[0];
            changed_hearts = i-1;
           
        }
        PlayerPrefs.SetInt("current_hearts", current_hearts);
    }

    public void FillTheHearts()
    {
        for (int i = 0; i < current_hearts; i++)
        {
            heart_images[i].sprite = heart_sprites[1];
            changed_hearts = i+1;
        }
        PlayerPrefs.SetInt("current_hearts", current_hearts);
    }


    IEnumerator WaitAndGameOver(int sec)
    {
        yield return new WaitForSeconds(sec);
        
    }

}

