using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static int buildIndex()
    {
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex;
        return nextBuildIndex;
    }

    public void closeTheGame()
    {
        Application.Quit();
    }

    public void startTheGame()
    {
        SceneManager.LoadScene(1);
        Messages.points = 0;
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
