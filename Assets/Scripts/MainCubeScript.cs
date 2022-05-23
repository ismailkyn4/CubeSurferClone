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
            Dead(); //dead fonksiyonunu çalýþtýrdýk.
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
        gameSound.PlayOneShot(audioClip); //ölme sesini bir kez çalýþtýrdýk.
        dead = true; 
        move = false;
        Invoke("PanelTime", 2f); //panelin açýlmasýný ölme gerçekleþtikten 2 saniye sonra aktif ettik. 
    }
    void PanelTime()
    {
        panel.SetActive(true);
        diamondText.SetActive(false);
        diamondImage.SetActive(false);
        starText.SetActive(false);
        starImage.SetActive(false);
        panelDiamondText.text =PlayerPrefs.GetInt("diamondScore").ToString(); //panelde kaydettiðimiz elmas miktarýný yazdýrdýk.
        panelStarText.text = PlayerPrefs.GetInt("starScore").ToString();
    }

}
