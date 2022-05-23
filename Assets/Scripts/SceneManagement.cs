using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject panel,playAgainBtn, quitBtn;
    public void PlayAgainBtn()
    {
        SceneManager.LoadScene("Game"); //play butonuna basýldýðýnda Game sahnesine geçiþ yapýyoruz.
    }
    public void QuitBtn()
    {
        Application.Quit(); //uygulamadan çýkmaya yarar.
    }
    
}
