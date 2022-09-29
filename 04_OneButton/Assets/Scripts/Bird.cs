using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    /// <summary>
    /// InputSystem 용 에셋 변수
    /// </summary>
    BirdInputActions inputActions;
    /// <summary>
    /// 물리 적용을 위한 리지드바드
    /// </summary>
    Rigidbody2D rigidbody;
    
    /// <summary>
    /// 죽었을 때 실행될 델리게이트
    /// </summary>
    public Action onDead;
    
    /// <summary>
    /// 점프력
    /// </summary>
    public float JumpPower = 7.0f;
    
    /// <summary>
    /// 위아래 회전 최대값
    /// </summary>
    public float pitchMaxAngle = 45.0f;
    /// <summary>
    /// 새가 죽었는지 살았는지 표시하는 값
    /// </summary>
    bool isDead = false;
    



    private void Awake() // 이 스크립트(컴포넌트)가 생성 완료 되었을 때
    {
        inputActions = new BirdInputActions(); // 인풋시스템 만든거 생성해오기
        rigidbody = GetComponent<Rigidbody2D>(); // 리지드바디 컴포넌트 찾기
        
    }

    private void Start() // 첫 번째 Update 함수가 실행되기 직전
    {
        isDead = false; // 우선 살아있다고 표시
    }

    private void OnEnable() // 오브젝트가 활성화 될때
    {
        inputActions.Bird.Enable();   // Bird 액션맵에 들어있는 액션들을 처리하겠다.
        inputActions.Bird.Jump.performed += OnJumpInput; 

    }

    private void OnDisable()
    {
        inputActions.Bird.Jump.performed -= OnJumpInput;  // Move 액션에 연결된 키가 눌러졌을 때 실행되는 함수를 연결(바인딩)
        inputActions.Bird.Disable();  // Player 액션맵에 있는 액션들은 처리하지 않겠다.
    }

    private void Update() // 매프레임 마다
    {

    }

    float temp = 0.0f;
    private void FixedUpdate() // 물리 업데이트 추가마다(고정된 시간) , FixedUpdate는 물리연산인 리지드 바디로 이동을 처리해야된다.
    {
        if (!isDead) // 살아있을때만 아래 코드 실행!
        {
            //rigidbody.velocity.y; // + 이면 새가 위로 올라가고 있다. - 면 새가 아래로 내려가고 있다.
            //rigidbody.MoveRotation();
            float velocityY = Mathf.Clamp(rigidbody.velocity.y, -JumpPower, JumpPower);// 최대로 올라가거나 내려가는 범위만 나오도록 제한, 점프값에대해서, 왜냐하면 벨로시티값은 매프레임마다 변하니깐...
            float angle = (velocityY / JumpPower) * pitchMaxAngle; // 각도는 + . - 피치맥스앵글의 각도로 맞춰준다.
            rigidbody.MoveRotation(angle); // 각도만큼 돌려주기

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌했을때 실행!
    {
        Die(collision.GetContact(0)); // 충돌환 지점에 대한 정보 전달
    }
   

    private void OnJumpInput(InputAction.CallbackContext context)
    { 
        //rigidbody.AddForce(Vector2.up * JumpPower,ForceMode2D.Impulse); // 위쪽으로 점프힘 가해주기, 리지드바디로
        rigidbody.velocity = Vector2.up * JumpPower; // 동일한 기능 제공하고 더 자세히 값 확인가능
        // 위쪽 방향으로 점프력만큼 velocity 변경
    }


    void Die(ContactPoint2D contact)
    {

      Vector2 dir = (contact.point - (Vector2)transform.position).normalized; //새가 충돌지점으로 가는 방향벡터
                                                                            //순수하게 방향벡터만 만들기
      Vector2 reflect = Vector2.Reflect(dir, contact.normal); // dir이 반사된 벡터
      rigidbody.velocity = reflect * 10.0f + Vector2.left * 5.0f; //반사되는 방향에서 왼쪽으로 가하는 힘 주기!
      rigidbody.angularVelocity = 1000.0f; // 회전추가(초당 1000도)


        if (!isDead) // 죽었을때 한번만 입력 막기! -> 불필요한 연산 막기위해서
        {   
            //아직 살아 있다고 표시될때만 실행
            onDead?.Invoke(); // 사망 알림용 델리게이트 실행
            inputActions.Bird.Disable(); // 입력받는거 다막아버리기!
            isDead = true;
        }
    }

  
  
}