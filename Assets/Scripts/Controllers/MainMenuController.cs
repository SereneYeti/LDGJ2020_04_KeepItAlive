using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button btnPlay;
    public Button btnModifiers;
    public Button btnQuit;
    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        //btnPlay = GetComponentInChildren<Button>();
        //btnModifiers = GetComponentInChildren<Button>();
        //btnQuit = GetComponentInChildren<Button>();

        btnPlay.onClick.AddListener(PlayGame);
        //btnModifiers.onClick.AddListener(GenerateModifiers); 
        btnQuit.onClick.AddListener(QuitGame);
       
        message.text = game_Manager.Instance.killedBy + "\nYou had " + game_Manager.Instance.finalHealth + " health left.\nYou had " + game_Manager.Instance.finalO2 + " oxygen left.\nYou killed " + game_Manager.Instance.lostKilled + " lost!";


    }

    void GenerateModifiers()
    { }

    void PlayGame ()
    {
        Debug.Log("Test");
        SceneManager.LoadScene("Level 1");
    }

    void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
