using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 dir;


    // 유니티 이벤트 함수 : 유니티가 특정 타이밍에 실행 시키는 함수

    /// <summary>
    /// Start 함수. 게임이 시작될 때(첫번째 Update 함수가 호출되기 직전에 호출되는 함수) 호출되는 함수
    /// </summary>
    private void Start()
    {
        Debug.Log("Hello Unity");
    }

    /// <summary>
    /// Update 함수. 매 프레임마다 호출되는 함수. 지속적으로 변경되는 것이 있을 때 사용하는 함수.
    /// </summary>
    private void Update()
    {
        // Vector3 : 벡터를 표현하기 위한 구조체. 위치를 표현할 때도 많이 사용한다.
        // 벡터 : 힘의 방향과 크기를 나타내는 단위

        //transform.position += new Vector3(1, 0, 0);        

        //new Vector3(1, 0, 0);   // 오른쪽 Vector3.right;
        //new Vector3(-1, 0, 0);  // 왼쪽   Vector3.left;
        //new Vector3(0, 1, 0);   // 위쪽   Vector3.up;
        //new Vector3(0, -1, 0);  // 아래쪽 Vector3.down;

        //transform.position += (Vector3.down * speed );   // 아래쪽 방향으로 speed 만큼 움직여라(매 프레임마다)

        // Time.deltaTime : 이전 프레임에서 지금 프레임까지 걸린 시간 => 1프레임당 걸린 시간
        //transform.position += (Vector3.down * speed * Time.deltaTime);  // 아래쪽 방향으로 speed 만큼 움직여라(매 초마다)
        //transform.position += (speed * Time.deltaTime * Vector3.down);


        // Input Manager를 이용한 입력 처리
        // Busy wait이 발생.( 하는일은 없지만 사용되고 있는 상태 => 전력 세이빙을 방해 => 전력 커짐 )
        //Test_OldinputManager(); // 예전에 이용하는 인풋매니저
        transform.position += (speed * Time.deltaTime * dir);

        // Input System
        // Event-driven(이벤트 드리븐) 방식으로 구현 -> 일이 있을 때만 동작한다.(전력을 아끼기에 적합한 구조)
    }

    private void Test_OldinputManager()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W가 눌러졌다.");
            dir = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A가 눌러졌다.");
            dir = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S가 눌러졌다.");
            dir = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D가 눌러졌다.");
            dir = Vector3.right;
        }
    }
}
