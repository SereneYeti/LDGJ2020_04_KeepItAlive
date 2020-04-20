using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class DeadthScreenContoller : MonoBehaviour
{
    public Button btnPlay;
    public Button btnQuit;
    public Text message;
    // Start is called before the first frame update
    void Start()
    {
        //btnPlay = GetComponentInChildren<Button>();
        //btnQuit = GetComponentInChildren<Button>();

        
        btnPlay.onClick.AddListener(this.PlayGameAgain);
        btnQuit.onClick.AddListener(this.QuitGame);
        message.text = game_Manager.Instance.killedBy + "\nYou had " + game_Manager.Instance.finalHealth + " health left.\nYou had " + game_Manager.Instance.finalO2 + " oxygen left.\nYou killed " + game_Manager.Instance.lostKilled + " lost!";

    }
    // Update is called once per frame
    void Update()
    {

    }
    void PlayGameAgain()
    {
        //Debug.Log("PlayAgain");
        SceneManager.LoadScene("Level 1");
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
