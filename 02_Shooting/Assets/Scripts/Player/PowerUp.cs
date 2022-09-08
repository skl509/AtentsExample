using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float dirChangeTime = 1.0f; // 파워업 아이템의 이동방향이 바뀌는 시간 변수
    public float moveSpeed = 0.5f; // 이동속도 변수
    public float selfDestroyTime = 10.0f; // 스스로 없어지는 시간 변수

    Player player;        // 파워업 아이템의 이동방향 설정에 플레이어 정보(좌표)
    Vector2 dir;          // 현재 이동 방향
    WaitForSeconds waitTime; // 코루틴에서 사용하기 위한 기다리는 시간 간격

    private void Start() // 초기설정
    {
        waitTime = new WaitForSeconds(dirChangeTime); //dirChangeTime 만큼 기다리도록 wait Time 미리 생성...        player = FindObjectOfType<Player>(); // player 의 좌표 불러들이기 위해서...
        player = FindObjectOfType<Player>();// Player 타입을 찾기(좌표...) , 무조건 한개만 찾기! 여러개 있을경우 뭐가 들어올지 모르기 때문에
        SetRandomDir(); // 랜덤하게 현제 이동 방향 설정
        StartCoroutine(DirChange()); // 아래 코드 대기(함수만큼...)
        Destroy(this.gameObject, selfDestroyTime); // slef DestroyTime 이후 오브젝트 삭제...
    }

    private void Update() // 매 프레임 마다 실행 -> 델타타임(Time.deltaTime)이라 매초 마다 실행...
    {
        transform.Translate(moveSpeed * Time.deltaTime * dir); // 현재 이동방향으로 초당 move 스피드 만큼 이동...
    }

    IEnumerator DirChange() // 초당 방향 변경위해서 코루틴 이용
    {
        while(true) // 무한반복
        {
            yield return waitTime; //wait 타임만큼 대기...
            SetRandomDir(false); // 랜덤하게 현재 이동방향 설정
        }
    }

    void SetRandomDir(bool allRandom = true)    // 디폴트 파라메터. 값을 지정하지 않으면 디폴트 값이 대신 들어간다.
    {
        if (allRandom)
        {
            dir = Random.insideUnitCircle; // 랜덤 방향으로 방향 설정(반지름이 1인 원), 원의 중심에서 아무 방향이나 간다 생각
            dir = dir.normalized; // 항상 가는 크기가 1 이상이 되기 때문에 1~0사이로 노멀라이즈 해주기...
        }
        else // 플레이어 반대방향 또는 플레이어방향 으로 설정
        {
            Vector2 playerToPowerUp = transform.position - player.transform.position; //플레이어 위체에서 파워 아이템 위치 방향벡터...
            playerToPowerUp = playerToPowerUp.normalized; // 위의 방향벡터를 단위벡터로 변경
            if (Random.value < 0.6f)    // 60% 확률로 플레이어 반대방향으로 이동
            {
                // playerToPowerUp 벡터를 z축으로 -90~+90만큼 회전시켜서 dir에 넣기
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;
            }
            else  // 40% 확률로 플레이어 방향으로 이동
            {
                dir = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * -playerToPowerUp;
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {// 보더랑 충돌하면 dir 반사... (벡터 방향 바꿔주기,Reflect)
            dir = Vector2.Reflect(dir, collision.contacts[0].normal);
        }
    }
}
