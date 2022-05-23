using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    GameObject mainCube;
    int height;

    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }
    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, height+1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0); //toplay�c� kub�n�n local pozisyonunu belirledik.
    }
    public void DecreaseHeight()
    {
        height--;
        
        if (height<0) //y�kseklik de�eri s�f�r�n alt�na d��t���nde y�kseklik de�erini s�f�rda sabitliyoruz.
        {
            height = 0;
        }
    }
    public void PoolDecreaseHeight()
    {
        StartCoroutine(PoolDecreaseHeightRoutine());
    }
    IEnumerator PoolDecreaseHeightRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        height--; 
        yield return new WaitForSeconds(1f); //y�ksekli�i azalt�p 1 saniye beklettik.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sum" && other.gameObject.GetComponent<CollectibleCube>().DidItGatter() == false)
        {
            height += 1; //y�ksekli�i 1 art�rd�k.
            other.gameObject.GetComponent<CollectibleCube>().MakeGatter(); //ToplanabilirKup scriptindeki topland�yap fonk tetikledik.
            other.gameObject.GetComponent<CollectibleCube>().SetIndex(height); //collectibleCube scriptinin SetIndex fonksiyonuna height de�erini atad�k.
            other.gameObject.transform.parent = mainCube.transform; //�arp�lan nesneyi �arpan nesnenin childi yapt�k.
        }
    }

    public float Height()
    {
        return height; //y�kseklik de�erini return ettik.
    }
}
