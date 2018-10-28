using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // !!!!!! buttons etc.
using UnityEngine.SceneManagement; //scene management

public class CharacterSelection : MonoBehaviour {


    public Button AsaButton, HatoButton, StartButton;
    public GameObject asa_model, hato_model; 

    public string PlayersChoice;

    private Text hText, aText;


    // Use this for initialization
    void Start () {

        AsaButton = GameObject.FindGameObjectWithTag("ButtonA").GetComponent<Button>();  // przypisanie button jako gameobject!!!
        HatoButton = GameObject.FindGameObjectWithTag("ButtonH").GetComponent<Button>();
        StartButton = GameObject.FindGameObjectWithTag("ButtonStart").GetComponent<Button>();
        asa_model = GameObject.Find("asa");
        hato_model = GameObject.Find("hato");

        AsaButton.interactable = true;
        HatoButton.interactable = true;

        asa_model.SetActive(true);
        hato_model.SetActive(false);

        aText = AsaButton.GetComponentInChildren<Text>();
        hText = HatoButton.GetComponentInChildren<Text>();

        //domyślne
        PlayersChoice = "asa";
        PlayerPrefs.SetString("Character_Selected", PlayersChoice);
        PlayerPrefs.SetString("Character_Follower", "hato");
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("gracz to: " + PlayerPrefs.GetString("Character_Selected") + ",  a follower to: " + PlayerPrefs.GetString("Character_Follower"));
    }

    public void AsaSelectCharacterButtonClick()
    {
        PlayersChoice = "asa";
        asa_model.SetActive(true);
        hato_model.SetActive(false);
        PlayerPrefs.SetString("Character_Selected", PlayersChoice);
        PlayerPrefs.SetString("Character_Follower", "hato");
    }

    public void HatoSelectCharacterButtonClick()
    {      
        PlayersChoice = "hato";
        asa_model.SetActive(false);
        hato_model.SetActive(true);
        PlayerPrefs.SetString("Character_Selected", PlayersChoice);
        PlayerPrefs.SetString("Character_Follower", "asa");
    }

    public void HatoButtonHover()
    {
        hText.color = Color.red;
    }

    public void AsaButtonHover()
    {
        aText.color = Color.red;
    }

    public void HatoButtonUnhover()
    {
        hText.color = Color.black;
    }

    public void AsaButtonUnhover()
    {
        aText.color = Color.black;
    }

    public void StartButtonClick()
    {
        SceneManager.LoadSceneAsync("scene6city");
 
    }
}

