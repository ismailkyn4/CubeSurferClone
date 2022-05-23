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
        this.transform.localPosition = new Vector3(0, -height, 0); //toplayýcý kubünün local pozisyonunu belirledik.
    }
    public void DecreaseHeight()
    {
        height--;
        
        if (height<0) //yükseklik deðeri sýfýrýn altýna düþtüðünde yükseklik deðerini sýfýrda sabitliyoruz.
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
        yield return new WaitForSeconds(1f); //yüksekliði azaltýp 1 saniye beklettik.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sum" && other.gameObject.GetComponent<CollectibleCube>().DidItGatter() == false)
        {
            height += 1; //yüksekliði 1 artýrdýk.
            other.gameObject.GetComponent<CollectibleCube>().MakeGatter(); //ToplanabilirKup scriptindeki toplandýyap fonk tetikledik.
            other.gameObject.GetComponent<CollectibleCube>().SetIndex(height); //collectibleCube scriptinin SetIndex fonksiyonuna height deðerini atadýk.
            other.gameObject.transform.parent = mainCube.transform; //çarpýlan nesneyi çarpan nesnenin childi yaptýk.
        }
    }

    public float Height()
    {
        return height; //yükseklik deðerini return ettik.
    }
}
