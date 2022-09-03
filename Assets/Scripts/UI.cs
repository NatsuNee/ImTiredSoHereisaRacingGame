using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playScreen;
    public GameObject garageScreen;
    public GameObject settingsScreen;

    public void EmptyScreen()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSelector()
    {
        playScreen.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Settings()
    {

    }
    public void Garage()
    {

    }

}
