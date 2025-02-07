using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuesController : MonoBehaviour
{
    public void LoadSceneOne()
    {
        SceneManager.LoadScene("SceneOne");
    }
    public void LoadSceneMainManue()
    {
        SceneManager.LoadScene("MainManue");
    }
    public void LoadSceneDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }
    public void LoadSceneWin()
    {
        SceneManager.LoadScene("WinScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
