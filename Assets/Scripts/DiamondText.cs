using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiamondText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI diamondScoreText;
    public static int diamondAmount;
    void Start()
    {
        diamondScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
            diamondScoreText.text = diamondAmount.ToString(); //elmasScore textine elmas miktar�n� stringe d�n��t�r�p yazd�k.
    }
}
