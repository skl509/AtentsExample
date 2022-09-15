using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;
    public float JumpPower = 5.0f;

    float moveDir = 0.0f;
    float rotateDir = 0.0f;

    Rigidbody rigid;

    PlayerInputActions inputActions; // 변수 선언만 한것

    private void Awake()
    {
        inputActions = new PlayerInputActions(); // 변수사용위해서 인스턴스 생성
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable() // 어떤 액션맵을 이용할지 활성화 작업
    {
        inputActions.Player.Enable(); // Player 액션맵에 들어있는 액션들을 처리하겠다.
        inputActions.Player.Move.performed += OnMoveInput; // Move 액션에 연결된 키가 눌러졌을 때 실행되는 함수를 연결(바인딩)
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Jump.performed += OnJumpInput;
    }

    
    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMoveInput; // 바인딩 해제
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Jump.performed -= OnJumpInput;
        inputActions.Player.Disable(); // Player 액션맵에 들어있는 액션들을 처리하지 않하겠다.
    }
    private void FixedUpdate()
    {
        Move();
        Rotate();


    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>(); // 입력된 값을 받아오는 것
        Debug.Log(input);
        moveDir = input.y; // w 가 +1 이고 s 가 -1 이다. 왼손좌표계에서 전진, 후진 인지 결정
        rotateDir = input.x; // a 가 -1 이고 d 가 +1 이다 ,왼손좌표계에서 d 가 오른쪽으로 가니깐 +1(손으로 휘잡았을때 시계방향)
    }


    private void OnJumpInput(InputAction.CallbackContext obj)
    {   //플레이어의 위쪽 방향(up)으로 JumpPower 만큼 즉시 힘 추가한다.(질량 포함)
        rigid.AddForce(transform.up * JumpPower,ForceMode.Impulse);
         
    }




    // 좌회전인지 우회전인지 결정      
    void Move() 
    {
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * -moveDir * transform.forward); // 축을 잘못 만들어서 - 방향에 붙여줌 그래야 정방향으로 가니깐
        //transform.forward 방향 개념이 아니라 크기개념으로 밀어주는 걸로 생각
    }

    void Rotate() 
    {   //리지드 바디로 회전 설정
        //rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0, rotateDir * rotateSpeed * Time.fixedDeltaTime, 0));
        rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(-rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up)); // 축을 잘못 만들어서 - 회전방향에 붙여줌 그래야 정방향으로 가니깐
        //각도는 더해주는게 아니라 곱해줘야 적용된다.
        //   Quaternion.Euler(0,rotateDir*rotateSpeed*Time.fixedDeltaTime, 0) // x,z 축은 회전 값없이 y축 기준으로 회전      
        //    Quaternion.AngleAxis(rotateDir*rotateSpeed*Time.fixedDeltaTime, transform.up) // 플레이어의 Y 축 기준으로 회전
    }





}
