using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator anim; //karakter animat�r�ne eri�ebilmek i�in Animat�r de�i�keni olu�turduk.
    MainCubeScript mainCube;
    void Start()
    {
        anim = GetComponent<Animator>(); 
        mainCube = Object.FindObjectOfType<MainCubeScript>();
    }

    void Update()
    {
        if (mainCube.dead) //mainCube scriptinden dead de�erini �ektik ve kontrol ettik.
        {
            anim.SetTrigger("dead");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Barrier")
        {
            mainCube.dead = true;
        }
    }
}
