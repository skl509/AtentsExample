using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    GameObject explosion;

    float spawnY; //소환된 적 위치의 y 값을 저장하는 변수
    float timeElepsed; // 시간경과 변수 , 게임 시작부터 얼마나 시간이 지낫는가...

    public float heightDiff; // 사인으로 변경되는 위아래 차이, 원래 sin은 -1 ~ +1 인데 그것을 변경하는 변수
    public float frequencyTime; //사인 그래프가 한번 도는데 걸리는 시간(주기결정)(원래 2파이 라디안인데 그것을 수정하는 것) 

    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        //explosion.SetActive(false); // 활성화 상태를 끄기(비활성화)
        spawnY = transform.position.y;
        timeElepsed = 0.0f; 


    }

    private void Update()
    {  // Time.deltaTime : 이전 프레임에서 현제 프레임까지의 시간, update 함수라서 초당기록
        timeElepsed += Time.deltaTime; // 시간경과 하는 변수 생성, update 함수에서 초당 처리되기때문에 초속으로 결정됨
        float newY = spawnY + Mathf.Sin(timeElepsed); // Y생성 지점에서 초속 sin 함수 방향으로 진행
        float newX = transform.position.x - speed * Time.deltaTime;//현제 x 위치에서 왼쪽으로(-방향) 진행...

        transform.position = new Vector3(newX, newY);

        

        //transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World );
        //transform.Translate(speed * Time.deltaTime * new Vector3(-1,0), Space.Self);  // new로 새로 만들기 때문에 Vector3.left를 쓰는 것보다는 느리다.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.CompareTag("Bullet") )
        {
            //GameObject obj = Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(obj, 0.42f);
            explosion.SetActive(true);  // 총알에 맞았을 때 익스플로젼을 활성화 시키고
            explosion.transform.parent = null;  // 익스플로전의 부모(Enemy) 연결을 제거한다.

            Destroy(this.gameObject);   // Enemy를 파괴한다.
        }
    }
}
