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
        PlayerPrefs.DeleteKey("diamondScore"); //hafýzada diamondScore adýnda kayýtlý bir veri varsa verileri sil. Elmas deðeri her baþladýðýnda sýfýrdan baþlamasý için.
        PlayerPrefs.DeleteKey("starScore");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Sum" && gameObject.tag=="diamond") //eðer çarpýlan nesnenin tagi Sum ve çarpan nesnenin tagi diamond(elmas) ise yapýlacaklar
        {
            DiamondText.diamondAmount += 1; //diamondText scriptindeki diamond amount miktarýný 1 artýr.
            PlayerPrefs.SetInt("diamondScore",DiamondText.diamondAmount); //oyun bittikten sonra panelde gösterebilmek için elmas miktarýný bellekte tutuyoruz.
            diamondEfect.transform.position = transform.position; //elmas efektinin çalýþacaðý yeri çarpýþma noktasý olarak ayarladýk.
            diamondEfect.GetComponent<ParticleSystem>().Play(); 
            Destroy(gameObject); //elmasý yok ettik.
            GetComponent<BoxCollider>().enabled = false; //elmasýn çarpýþma özelliðini false etti yoksa 2 kez çarpýþýyo puan 2 artýyo
        }
        if (other.tag == "Sum" && gameObject.tag == "star") //eðer çarpýlan nesnenin tagi Sum ve çarpan nesnenin tagi star(yýldýz) ise yapýlacaklar
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
