using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 0.001f; // public 을 선언하면 플레이 도중 값이 변경이 가능하다

    // 유니티 이벤트 함수 : 유니티가 특정 타이밍에 실행 시키는 함수

    //Start 함수 : 게임이 시작될 때(최초의 Update 함수가 호출되기 직전에)호출되는 함수
    private void Start()
    {
        Debug.Log("Hello Unity");
    }

    private void Update()  // Update 함수 : 매 프레임마다 호출되는 함수
    {
        //Vector3 a = new Vector3();
        //a.x;
        //a.y;
        //a.z;
        //Vector 3 : 벡터를 표현하기 위한 구조체, 위치를 표현할때도 많이 사용한다.
        //벡터 : 힘의 방향과 크기를 나타내는 단위

        //transform.position += (Vector3.down * speed);
        // 아래쪽 방향으로 스피드 만큼 움직여라...(매 프레임 마다) 

        //transform.position += new Vector3(1, 0, 0);

        //new Vector3(1, 0, 0); // 오른쪽 Vector3.right;
        //new Vector3(-1, 0, 0); // 왼쪽  Vector3.left;
        //new Vector3(0, 1, 0); // 위쪽   Vector3.up;
        //new Vector3(0, -1, 0);// 아래쪽 Vector3.down;



        //transform.position += (Vector3.down * speed*Time.deltaTime); //아래쪽 방향으로 스피드 만큼 움직여라...(매초 마다) 
        // Time.deltaTime : 이전 프레임에서 지금 프레임까지 걸린 시간 -> 1프레임당 걸린시간
        //매초마다 걸리게 만들어 줘야하는 이유는 매 프레임으로 하면 컴퓨터 성능별로 다르게 표현된다.
        //그러면 큰 성능 차이를 만들기 때문에 조심해야됨
        transform.position += (speed * Time.deltaTime * Vector3.down); // 쓸때는 곱해지는 횟수가 많아지는 걸 뒤쪽에 넣어야 효율적

    }
}
