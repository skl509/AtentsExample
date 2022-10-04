using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ImageNumber : MonoBehaviour
{   

    public int expectedLength = 6; // 예상되는 자리수
    public GameObject digitPrefab; // 숫자 하나를 표현할 프리팹
    public Sprite[] numberImages = new Sprite[10]; // 숫자 0~9까지 있는 스프라이트


    List<Image> digits; // 0번째가 1자리, 1번째가 10자리
    List<int> remainders;

    public float numberChnageSpeed = 10.0f;
    float currentNumber = 0.0f;

    

    int number;
    public int Number
    {
        get => number;
        set => number = value;
    }
    private void Awake()
    {
        digits = new List<Image>(transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {

            digits.Add(transform.GetChild(i).GetComponent<Image>());

        }
        remainders = new List<int>(expectedLength); // 자료구조를 만들때는 기본 크기를 잡아주는 편이 좋다.
    }
       


           //int mod = number % 10; // 인티저 값이라 10으로 나눈 후 나머지 값은 각자리수의 값이된다
           //digits[0].sprite = numberImages[mod];
   
    private void Update()
    {
       
        if ((int)currentNumber != Number)  // currentNumber가 Number와 같아졌는지 확인, 다를 때만 아래 코드 실행
        {   
            float dir = (currentNumber > Number)? -1 : 1; // currentNumber가 변화하는 방향구하기
            float speed = numberChnageSpeed * Mathf.Pow(10, digits.Count); // 속도가 자리수에 비례해서 증가하게 수정
            currentNumber += dir * speed * Time.deltaTime; // 방향에 따라 초당 numberChnageSpeed 만큼 currentNumber 변화
            if (dir > 0)
            {
                currentNumber = Mathf.Min(currentNumber, Number);//currentNumber의 방향이 증가일 때 목표인 Number를 넘친 경우 Number로 선택
            }
            else
            {
                currentNumber = Mathf.Max(currentNumber, Number);//currentNumber의 방향이 감소일 때 목표인 Number밑으로 간경우 Number로 선택

            }
            int tempNum = (int)currentNumber; // 표시할 숫자 결정(currentNumber에서 소수점 제거한 숫자)

            remainders.Clear(); //자리수 별로 저장하는 리스트 일단 일단 비우기

            do // do ~ while 먼저 한번 do 에서 실행하고 while 돌려주기
            {
                remainders.Add(tempNum % 10); // 3-> 2 -> 1
                tempNum /= 10; // 12 -> 1 -> 0

            }
            while (tempNum != 0);  // 123으로 시작했을때

            // 자리수에 맞게 digits 증가 또는 감소 시켜주기!
            // -> 이미지 배열이랑 리스트 배열이랑 비교 (길이 비교해주기!)
            int diff = remainders.Count - digits.Count;
            if (diff > 0) //들어오는 수가 더 많아서 digits 증가!
            {
                for (int i = 0; i < diff; i++)
                {
                    GameObject obj = Instantiate(digitPrefab, transform);
                    obj.name = $"Digit{Mathf.Pow(10, digits.Count)}"; // 1자리는 1, 10자리는 10, 100자리는 100
                    digits.Add(obj.GetComponent<Image>());
                }
                //digits 증가, 나머지들의 자리수가 더 기니까
            }
            else if (diff < 0)//들어오는 수가 더 작아서 digits 감소!
            {
                for (int i = digits.Count + diff; i < digits.Count; i++)
                {
                    digits[i].gameObject.SetActive(false);

                }
                // digits 감소, 나머지들의 자리수가 더 작으니까
            }
            // 자리수별로 숫자 설정
            for (int i = 0; i < remainders.Count; i++)
            {
                digits[i].sprite = numberImages[remainders[i]];
                digits[i].gameObject.SetActive(true);
            }
        }
    }

}
