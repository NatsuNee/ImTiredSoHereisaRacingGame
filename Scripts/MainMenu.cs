using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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

    public void StoryMode()
    {
        SceneManager.LoadScene("Town");
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("TestDriving");
    }
    public void Settings()
    {

    }
    public void Garage()
    {

    }

}
