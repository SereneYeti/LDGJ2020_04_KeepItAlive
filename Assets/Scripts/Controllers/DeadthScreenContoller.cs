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

        btnPlay.onClick.AddListener(PlayGame);
        btnQuit.onClick.AddListener(QuitGame);
        message.text = game_Manager.Instance.killedBy + "\nYou had " + game_Manager.Instance.finalHealth + " health left.\nYou had " + game_Manager.Instance.finalO2 + " O2 left.\n This makes humanity " + game_Manager.Instance.lostKilled + " dead lost closer to salvation.";

    }

    void PlayGame()
    {
        Debug.Log("Test");
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
