using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject panel,playAgainBtn, quitBtn;
    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Game"); //play butonuna bas�ld���nda Game sahnesine ge�i� yap�yoruz.
    }
    public void QuitBtn()
    {
        Application.Quit(); //uygulamadan ��kmaya yarar.
    }
    
}
