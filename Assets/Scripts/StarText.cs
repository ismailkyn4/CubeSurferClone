using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starScoreText;
    public static int  starAmount;


    void Start()
    {

        starScoreText = GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {
        starScoreText.text = starAmount.ToString();  //y�ld�zScore textine y�ld�z miktar�n� stringe d�n��t�r�p yazd�k.
    }

}
