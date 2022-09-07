using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifePannel : MonoBehaviour
{
    TextMeshProUGUI lifeText;

    private void Awake()
    {
        lifeText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();   
    }

    private void Start()
    {
        //        특정한 오브젝트 찾는 방법!
        //         1.Gameobject.Find(); // 이름으로 찾기
        //        2.Gameobject.FindGameObjectWithTag(); // 태그로 찾기
        //        3.GameObject.FindObjectOfType<>(); // 타입으로 찾기

        Player player = GameObject.FindObjectOfType<Player>(); // 타입으로 Plyaer 찾고
        player.onLifeChange += Refresh; // 델리게이트 함수 등록


    }


    private void Refresh(int life)
    {
        lifeText.text = life.ToString(); // 입력받은 Life 값으로 화면 갱신
        
    }

}
