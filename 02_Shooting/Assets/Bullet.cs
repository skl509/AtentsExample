using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

//Bullet이 계속 자신의 오른쪽 방향으로 이동하도록 코드를 작성하라.
public class Bullet : MonoBehaviour
{
    public float bulletspeed = 10.0f;
   

    Animator anim;
   
        private void Awake() // 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후 
    {                   // -> 1순위로 실행
        
        anim = GetComponent<Animator>(); //GetComponent 는 반드시 중요!! 애니메이터 찾아오는것

    }
    private void Update()
    {
        transform.Translate(bulletspeed * Time.deltaTime * Vector3.right, Space.Self); //Space.self 자기 기준, Space.World : 씬 기준  // Space.Self : 자기 기준, Space.World : 씬 기준 
        // vector 3 의 방향... 오른쪽으로만 감(1,0,0)

    }
}

