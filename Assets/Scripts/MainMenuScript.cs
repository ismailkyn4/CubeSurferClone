using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject panel, playBtn, quitBtn;
    private void Awake()
    {

    }
    public void StartBtn()
    {
        panel.SetActive(false);
        SceneManager.LoadScene("Game");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
