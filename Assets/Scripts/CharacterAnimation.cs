using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator anim; //karakter animatörüne eriþebilmek için Animatör deðiþkeni oluþturduk.
    MainCubeScript mainCube;
    void Start()
    {
        anim = GetComponent<Animator>(); 
        mainCube = Object.FindObjectOfType<MainCubeScript>();
    }

    void Update()
    {
        if (mainCube.dead) //mainCube scriptinden dead deðerini çektik ve kontrol ettik.
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
