using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button selectLevelButton;
    [SerializeField] private Button exitButton;
    void Start()
    {
        newGameButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });
        exitButton.onClick.AddListener(() => { Application.Quit(); });
    }

    
}
