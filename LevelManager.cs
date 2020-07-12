using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void credits()
    {
        SceneManager.LoadScene(2);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void startgame ()
    {
        SceneManager.LoadScene(1);
    }


     public void menu ()
    {
        SceneManager.LoadScene(0);
    }
}
