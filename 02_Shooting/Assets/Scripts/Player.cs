
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour // 따로 함수만들어서 드래그해 넣어주는게 아니라 바로 코딩으로 입력받는방법!
{
    PlayerInputAction inputActions;

    // public delegate void DelegateName(); // 이런 종류의 델리게이트가 있다(리턴없고 파라메터도 없는 함수를 저장하는 델리게이트)

    //public DelegateName de1; // DelegateName 타입으로 del 이라는 이름의 델리게이트를 만듬
    //Action del2; // 리턴타입이 void, 파라메터도 없는 델리게이트 del2를 만듬 -> 보통 이걸 많이씀
    //Action<int> del3; // 리턴타입이 void, 파라메터는 int 하나인 델리게이트 del3을 만듬
    //Func<int, float> del14; // 리턴타입이 int고 파라메터는 float 하나인 델리게이트 del4를 만듬


    public GameObject Bullet;
    public float fireInterval = 0.5f;

    float speed = 2.0f; //플레이어의 이동속도(초당 이동 속도)
    Vector3 dir; // 이동방향(입력에 따라 변경됨)
    Rigidbody2D rigid;
    float booster = 1.0f;
    //bool isFiring = false;
    //float fireTimeCount = 0.0f;

    Animator anim;

    IEnumerator fireCoroutine;

    private void Awake() // 이 스크립트가 들어있는 게임 오브젝트가 생성된 직후 
    {                   // -> 1순위로 실행
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>(); // 한번만 찾고 저장해서 계속 쓰기(메모리 더쓰고 성능아끼기)
        anim = GetComponent<Animator>(); //GetComponent 는 반드시 중요!! 애니메이터 찾아오는것

        fireCoroutine = Fire();
    }

    private void OnEnable() // 이 스크립트가 들어있는 게임 오브젝트가 활성화(체크되어있을때) 되었을때 호출
    {                       //-> 2순위로 실행    
        inputActions.Player.Enable();// 오브젝트가 생성되면 입력을 받도록 활성화
        inputActions.Player.Move.performed += OnMove; // performed 일때 OnMove 함수 실행하도록 연결
        inputActions.Player.Move.canceled += OnMove;  // canceled 일때 OnMove 함수 실행하도록 연결
        inputActions.Player.Fire.performed += OnFireStart; // 플레이할때 스페이스 치면 디버그 출력
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Bootster.performed += OnBooster;
        inputActions.Player.Bootster.canceled += OffBooster;
    }

    

  

    private void OnDisable()//이 스크립트가 들어있는 게임 오브젝트가 비활성화(체크해제되어있을때) 되었을때 호출
    {//일일이 함수 기능 만들어 주고 코딩해준 다음 반드시 여기도 넣어줘야된다! 안전성위해!
       // inputActions.Player.Bootster.performed -= OffBooster;
        //inputActions.Player.Bootster.performed -= OnBooster;     
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Player.Fire.canceled -= OnFireStop;
        inputActions.Player.Move.canceled -= OnMove; // 연결해 놓은 함수 해제(안전을 위해)
        inputActions.Player.Move.performed -= OnMove; //
        inputActions.Player.Disable(); // 오브젝트가 사라질때 더이상 입력을 받지 않도록 비활성화
    }

    private void Start() // 시작할때, 첫번째 Update 함수가 실행되기 직전에 호출.
    {                    // -> 3순위로 실행   

    }

    private void Update() // 매 프레임마다 호출. // 호출이 픽시드업데이트보다 많아 덜덜덜 거려보인다
    {
        //transform.position += (speed * Time.deltaTime * dir);
        
        
    }
    private void FixedUpdate() // 일정시간간격(물리업데이트 시간간격)으로 호출
    {
        //transform.Translate(speed * Time.fixedDeltaTime * dir);

        // 이 스크립트 파일이 들어있는 게임 오브젝트에서 Rigidbody2D 컴포넌트를 찾아 리턴(없으면 null)
        // 그런데 GetComponet는 무거움 함수ㅇ 옳다.)
        //GetComponent<Rigidbody2D>(); 

        //rigid.AddForce(speed * Time.fixedDeltaTime * dir); // 관성잇는 움직임을 할때 유용
        rigid.MovePosition(transform.position + booster *speed * Time.fixedDeltaTime * dir);
        //관성 없는 움직임 할때 유용
        // 처음에 부스터랑 스피드가 1이면 변화가 없다 그러나 부스터 변경되는 순간 2배로 변해서 이동속도 변화...

        //fireTimeCount += Time.fixedDeltaTime;
        
        //if (isFiring && fireTimeCount > fireInterval)
        //{
        //    Instantiate(Bullet, transform.position, Quaternion.identity);
        //    fireTimeCount = 0.0f;
        //}

    }

    private void OnCollisionExit2D(Collision2D collision) // Collider와 접촉이 떨어지는 순간
    {
        Debug.Log("OnCollisionExit2D");   
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("OnCollisionEnter2D"); // Collider와 부딪쳤을 때 실행
    }
    
    private void OnTriggerEnter2D(Collider2D collision) // 트리거와 들어갔을 때 실행
    {
        Debug.Log("OnTriggerEnter2D");
    }

   
    private void OnTriggerExit2D(Collider2D collision)// 트리거에서 나갔을 때 실행
    {
        Debug.Log("OnTriggerExit2D");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Exception : 예외 상황(무엇을 해야 할지 지정이 안되어 있는 예외 일때) -> 프로그램이 끝남
        //throw new NotImplementedException(); 
        // NotImplementedException 을 실행하라. => 코드구현을 알려주기 위해 강제로 죽이는 코드
        Vector2 inputDir = context.ReadValue<Vector2>();      // 어느방향으로 움직여야 하는지를 입력
        dir = inputDir;      
        Debug.Log("이동입력");
        //dir.y > 0 w 눌럿다
        //dir.y == 0 w,s중 아무것도 안눌럿다 또는 동시에 눌렀다
        //dir.y < 0 s를 눌럿다

        anim.SetFloat("InputY", dir.y); // Y 값을 설정해주는 것! 애니메이션 조건식에 따라 달라짐 up and down
        // 애니메이션 파라미터값 InputY 값에 dir.y 값 파라미터 설정해주기! -> SetFloat 함수 이용
        // Input Y 가 0보다 크거나 작은거 가 적용 될려면 dir.y 값이 입력되야됨
        // 결과적으로 InputY 값이 조절되어 애니메이션 기능이 작동됨! 
    }
    private void OnFireStart(InputAction.CallbackContext context) // 안쓰는거면 매개변수 _ 로 표시
    {
        //float value = Random.Range(0.0f, 10.0f);// value에는 0.0 ~ 10.0 의 랜덤값이 들어간다.
        //Debug.Log("발사!");
        //Instantiate(Bullet, transform.position, Quaternion.identity);

        //isFiring = true;
        StartCoroutine(fireCoroutine);
    }
    private void OnFireStop(InputAction.CallbackContext _) {

        //isFiring = false;
        //StopAllCoroutines();
        StopCoroutine(fireCoroutine);

    }// 안쓰는거면 매개변수 _ 로 표시

    IEnumerator Fire()
    {
        // yield return null; // 다음 프레임에 이어서 시작해라


        //yield return new WaitForSeconds(1.0f); // 1초 후에 이어서 시작해라

        while (true) {

            Instantiate(Bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireInterval);
        }

    }

    private void OnBooster(InputAction.CallbackContext obj)
    {
        //Throw new NotImplementedException();
        booster *= 2.0f;
        Debug.Log("부스터 2배 발동!");
    }
    private void OffBooster(InputAction.CallbackContext obj)
    {

        //throw new NotImplementedException();
        booster = 1.0f;
        Debug.Log("부스터 발동해제 !");
    }



}
