using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void mistake1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Credits()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void ileri()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void SuSava��()
    {
        SceneManager.LoadScene(5);
    }

    public void U�akKatlama()
    {
        SceneManager.LoadScene(9);
    }

    public void U�akU�urma()
    {
        SceneManager.LoadScene(10);
    }
}