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
        starScoreText.text = starAmount.ToString();  //yýldýzScore textine yýldýz miktarýný stringe dönüþtürüp yazdýk.
    }

}
