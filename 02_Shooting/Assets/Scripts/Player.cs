using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputAction inputActions;

    float speed = 1.1f;
    Vector3 dir;


    private void Awake() // 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후 
    {                   // -> 1순위로 실행
        inputActions = new PlayerInputAction();
    }

    private void OnEnable() // 이 스크립트가 들어있는 게임 오브젝트가 활성화(체크되어있을때) 되었을때 호출
    {                       //-> 2순위로 실행    
        inputActions.Player.Enable();// 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove; // performed 일때 OnMove 함수 실행하도록 연결
        inputActions.Player.Move.canceled += OnMove;  // canceled 일때 OnMove 함수 실행하도록 연결
    }

    

    private void OnDisable()//이 스크립트가 들어있는 게임 오브젝트가 비활성화(체크해제되어있을때) 되었을때 호출
    {
        inputActions.Player.Move.canceled -= OnMove; // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove; //
        inputActions.Player.Disable(); // 오브젝트가 사라질때 더이상 입력을 받지 않도록 비활성화
    }

    private void Start() // 시작할때, 첫번째 Update 함수가 실행되기 직전에 호출.
    {                    // -> 3순위로 실행   

    }

    private void Update() // 매 프레임마다 호출.
    {
        transform.position += (speed * Time.deltaTime * dir);
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : 예외 상황(무엇을 해야 할지 지정이 안되어 있는 예외 일때) -> 프로그램이 끝남
        //throw new NotImplementedException(); 
        // NotImplementedException 을 실행하라. => 코드구현을 알려주기 위해 강제로 죽이는 코드

        Debug.Log("이동입력");
    }
    public void MoveInput(InputAction.CallbackContext context)
    {
       
        Vector2 inputDir = context.ReadValue<Vector2>();// 어느방향으로 움직여야 하는지를 입력
        Debug.Log(inputDir);
        dir = inputDir;  // dir.x = inputDir.x; dir.y=inputDir.y; dir.z=0.0f
        // vetor2 타입으로 바꾸는게 아니라 vetor3 는 z=0 으로 고정되어 있어서 가능
    }

    public void FireInput(InputAction.CallbackContext context)
    {
        if (context.performed)

            Debug.Log("발사!!");

    }

}
