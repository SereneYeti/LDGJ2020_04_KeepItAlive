﻿using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        //btnPlay = GetComponentInChildren<Button>();
        //btnModifiers = GetComponentInChildren<Button>();
        //btnQuit = GetComponentInChildren<Button>();

        btnPlay.onClick.AddListener(PlayGame);
        //btnModifiers.onClick.AddListener(GenerateModifiers); 
        btnQuit.onClick.AddListener(QuitGame);
    
    }

    void GenerateModifiers()
    { }

    void PlayGame ()
    {
        Debug.Log("Test");
        SceneManager.LoadScene(1);
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