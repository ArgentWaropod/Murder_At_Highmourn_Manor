using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas Credits;
    public GameObject NamePannel;
    public TMP_InputField nameField;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.enabled = true;
        Credits.enabled = false;
        NamePannel.SetActive(false);
    }

    public void OpenCredits()
    {
        MainMenu.enabled = false;
        Credits.enabled = true;
    }
    public void CloseCredits()
    {
        MainMenu.enabled = true;
        Credits.enabled = false;
    }
    public void OpenName()
    {
        NamePannel.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
