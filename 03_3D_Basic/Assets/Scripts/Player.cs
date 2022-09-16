using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;
    public float jumpPower = 5.0f;

    float moveDir = 0.0f;
    float rotateDir = 0.0f;
    bool isJumping = false;

    GroundChecker checker;

    Rigidbody rigid;
    Animator anim;

    PlayerInputActions inputActions;                // // 변수 선언만 한것


    private void Awake()
    {
        inputActions = new PlayerInputActions();    // 변수사용위해서 인스턴스 생성
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        checker = GetComponentInChildren<GroundChecker>();
        checker.onGrounded += OnGround;

    }

    private void OnEnable() //어떤 액션맵을 이용할지 활성화 작업
    {
        inputActions.Player.Enable();   // Player 액션맵에 들어있는 액션들을 처리하겠다.
        inputActions.Player.Move.performed += OnMoveInput;  // Move 액션에 연결된 키가 눌러졌을 때 실행되는 함수를 연결(바인딩)
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Jump.performed += OnJumpInput;
    }


    private void OnDisable()
    {
        inputActions.Player.Jump.performed -= OnJumpInput;
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput;  // 바인딩 해제
        inputActions.Player.Disable();  // Player 액션맵에 있는 액션들은 처리하지 않겠다.
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();

        if (isJumping)
        {
            if (rigid.velocity.y < 0)
            {
                checker.gameObject.SetActive(true);

            }

        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();   // 입력된 값을 읽어오기
        //Debug.Log(input);
        moveDir = input.y;      //  w 가 +1 이고 s 가 -1 이다. 왼손좌표계에서 전진, 후진 인지 결정
        rotateDir = input.x;    //  a 가 -1 이고 d 가 +1 이다 ,왼손좌표계에서 d 가 오른쪽으로 가니깐 +1(손으로 휘잡았을때 시계방향)



        anim.SetBool("IsMove", !context.canceled); // 애니메이션의 파라미터 설정을 해제 하고 실행하게 만들어주기
        // 이동키를 눌렀으면 true, 아니면 false 값    
    }

    private void OnJumpInput(InputAction.CallbackContext _)
    {
        if (!isJumping) // 점프 중이 아닐 때만 점프
        {
            // 플레이어의 위쪽 방향(up)으로 jumpPower만큼 즉시 힘을 추가한다.(질량 영향있음)
            JumpStart();
        }
    }

    void Move()
    {
        // 리지드바디로 이동 설정
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * moveDir * transform.forward);
    }

    void Rotate()
    {
        // 리지드바디로 회전 설정
        //rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0, rotateDir * rotateSpeed * Time.fixedDeltaTime, 0));
        rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up));

        // Quaternion.Euler(0, rotateDir * rotateSpeed * Time.fixedDeltaTime, 0) // x,z축은 회전 없고 y축 기준으로 회전
        // Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up) // 플레이어의 Y축 기준으로 회전
    }

    void JumpStart()
    {
        rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        isJumping = true;

        checker.gameObject.SetActive(false);
    }

    void OnGround()
    {
        isJumping = false;
    }

}