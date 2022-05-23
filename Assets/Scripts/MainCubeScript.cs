using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainCubeScript : MonoBehaviour
{
    Picker picker;
    [SerializeField] AudioSource gameSound;
    [SerializeField] AudioClip audioClip;
    [SerializeField] private GameObject panel,diamondText,diamondImage,starText,starImage;
    [SerializeField] private TextMeshProUGUI panelDiamondText, panelStarText;

    public bool dead;
    bool move;
    private void Awake()
    {
        move = true;
        dead = false;
        gameSound = GetComponent<AudioSource>();
        picker = Object.FindObjectOfType<Picker>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Barrier") 
        {
            Dead(); //dead fonksiyonunu �al��t�rd�k.
        }
        if (other.gameObject.tag == "Pool")
        {
            Dead();
        }
    }
    public bool SetMove()
    {
        return move;
    }
    public void Dead()
    {   
        gameSound.Stop();//oyun sesini durdurduk.
        gameSound.PlayOneShot(audioClip); //�lme sesini bir kez �al��t�rd�k.
        dead = true; 
        move = false;
        Invoke("PanelTime", 2f); //panelin a��lmas�n� �lme ger�ekle�tikten 2 saniye sonra aktif ettik. 
    }
    void PanelTime()
    {
        panel.SetActive(true);
        diamondText.SetActive(false);
        diamondImage.SetActive(false);
        starText.SetActive(false);
        starImage.SetActive(false);
        panelDiamondText.text =PlayerPrefs.GetInt("diamondScore").ToString(); //panelde kaydetti�imiz elmas miktar�n� yazd�rd�k.
        panelStarText.text = PlayerPrefs.GetInt("starScore").ToString();
    }

}
