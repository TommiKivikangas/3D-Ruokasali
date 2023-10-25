using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        PlayerPrefs.SetFloat("score", 0);
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
