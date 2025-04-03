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
    public void LoadSceneTwo()
    {
        SceneManager.LoadScene("SceneTwo");
    }
    public void LoadUpgradeScene()
    {
        SceneManager.LoadScene("UpgradeScene");
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
    public void Unfreeze()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.canMove = true;
    }
    public void Freeze()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerController.canMove = false;
    }
}
