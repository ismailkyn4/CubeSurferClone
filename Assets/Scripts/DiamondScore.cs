using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
    [SerializeField] private Transform diamondEfect,starEfect;

    private void Awake()
    {
        diamondEfect.GetComponent<ParticleSystem>().Stop(); 
        starEfect.GetComponent<ParticleSystem>().Stop();
        DiamondText.diamondAmount = 0;
        StarText.starAmount = 0;
        PlayerPrefs.DeleteKey("diamondScore"); //haf�zada diamondScore ad�nda kay�tl� bir veri varsa verileri sil. Elmas de�eri her ba�lad���nda s�f�rdan ba�lamas� i�in.
        PlayerPrefs.DeleteKey("starScore");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Sum" && gameObject.tag=="diamond") //e�er �arp�lan nesnenin tagi Sum ve �arpan nesnenin tagi diamond(elmas) ise yap�lacaklar
        {
            DiamondText.diamondAmount += 1; //diamondText scriptindeki diamond amount miktar�n� 1 art�r.
            PlayerPrefs.SetInt("diamondScore",DiamondText.diamondAmount); //oyun bittikten sonra panelde g�sterebilmek i�in elmas miktar�n� bellekte tutuyoruz.
            diamondEfect.transform.position = transform.position; //elmas efektinin �al��aca�� yeri �arp��ma noktas� olarak ayarlad�k.
            diamondEfect.GetComponent<ParticleSystem>().Play(); 
            Destroy(gameObject); //elmas� yok ettik.
            GetComponent<BoxCollider>().enabled = false; //elmas�n �arp��ma �zelli�ini false etti yoksa 2 kez �arp���yo puan 2 art�yo
        }
        if (other.tag == "Sum" && gameObject.tag == "star") //e�er �arp�lan nesnenin tagi Sum ve �arpan nesnenin tagi star(y�ld�z) ise yap�lacaklar
        {
            StarText.starAmount += 2;
            PlayerPrefs.SetInt("starScore", StarText.starAmount);
            starEfect.transform.position = transform.position;
            starEfect.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
