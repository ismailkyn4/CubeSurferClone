using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    bool didItGatter; //toplandý mý ?
    int index;
    public Picker picker;
    void Start()
    {
        didItGatter = false;
    }
    void Update()
    {
        if (didItGatter)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Barrier")
        {
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("Time", 0.1f); //Time fonksiyonunu 1 saniye sonra çalýþtýrdýk.
            //transform.parent = null;
        }
        if (other.gameObject.tag == "Pool")
        {
            picker.PoolDecreaseHeight();
        }

    }
    public void Time()
    {
        picker.DecreaseHeight(); //picker scriptindeki decreaseHeight fonksiyonunu tetikledik.
    }
    public bool DidItGatter()
    {
        return didItGatter;
    }
    public void MakeGatter()
    {
        didItGatter = true;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
}
