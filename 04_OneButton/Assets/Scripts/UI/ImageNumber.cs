using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageNumber : MonoBehaviour
{
    public Sprite[] numberImages = new Sprite[10];


    Image[] digits;

    private void Awake()
    {
        digits = new Image[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            
            digits[i]=transform.GetChild(i).GetComponent<Image>();    
        
        }
                
    }

    int number;
    public int Number 
    {
        get => number;
        set 
        {
            number = value;


            int mod = number % 10; // 인티저 값이라 10으로 나눈 후 나머지 값은 각자리수의 값이된다
            digits[0].sprite = numberImages[mod]; 
        }
    }


}
