using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 360.0f;          // 회전 속도
    public float moveSpeed = 3.0f;              // 이동 속도
    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
    public float minRotateSpeed = 30f;
    public float maxRotateSpeed = 360f;

    public GameObject small;
    [Range(1, 16)] // 아래 스플릿 카운터 변수의 범위설정...
    public int splitCount = 3;
    public Vector3 direction = Vector3.left;    // 운석이 이동할 방향
    public int hitPoint = 3;

    GameObject explosion;
    SpriteRenderer renderer;


    private void Awake()
    {

        renderer = GetComponent<SpriteRenderer>();

        renderer.flipY = true;
        renderer.flipX = false;

        int r = Random.Range(0, 4);
        renderer.flipX = ((r & 0b_01) != 0);
        // ((r & 0b_01)  : r의 제일 오른쪽 비트가 0인지 1인지 확인하는 작업!
        //((r & 0b_01) != 0 : r의 제일 오른쪽 비트가 1이면 true, 0이면 false
        renderer.flipY = ((r & 0b_10) != 0);
        // ((r & 0b_10)  : r의 제일 오른쪽에서 두번째 비트가 0인지 1인지 확인하는 작업
        // ((r & 0b_10) != 0 : r의 제일 오른쪽에서 두번째 비트가 1이면 true, 0이면 false

        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        float ratio = (moveSpeed - minMoveSpeed) / (maxMoveSpeed - minMoveSpeed);
        // rotateSpeed = ratio * (maxRotateSpeed - minRotateSpeed) + minRotateSpeed;
        rotateSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, ratio);
    }




    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;
        StartCoroutine(Dead());
    }

    void Update()
    {
        
        //transform.rotation *= Quaternion.Euler(new(0, 0, 90));  // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0, 0, rotateSpeed * Time.deltaTime));    // 1초에 rotateSpeed도씩 회전
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);   // Vector3.forward 축을 기준으로 1초에 rotateSpeed도씩 회전

        transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);
       

    }
    IEnumerator Dead()
    {
        float r1 = Random.Range(4.0f, 6.0f);
        yield return new WaitForSeconds(r1); // 지정된 시간 후에 뒤에 함수실행한다.
        Crush();
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + direction * 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitPoint--;

            if (hitPoint <= 0)
            {
                Crush();
            }
            
        }

    }

    void Crush()
    {
        explosion.SetActive(true);
        explosion.transform.parent = null;
        if (Random.Range(0.0f, 1.0f) < 0.05f) //5% 확률로 와장창 나온다...
        {
            splitCount = 20;
        }
        else 
        {
            splitCount = Random.Range(3, 10);
        }
        float angleGap = 360.0f / (float)splitCount;
        float r = Random.Range(15.0f, 35.0f);
        for (int i = 0; i < splitCount; i++)
        {
            if (i == 0) {
                Instantiate(small, transform.position, Quaternion.Euler(0, 0, r));
            }
            else
            { Instantiate(small, transform.position, Quaternion.Euler(0, 0, (angleGap * i)));
                // 각도설}정은 쿼터니언 오일러 z 축이다...
            }
            Destroy(this.gameObject);
        } // 강사님은 else 안나누고 for 문 계산 변경했음. for 문에다가 ((anagleGap*i)+ r)....
          // 왜냐면 for 문 0번부터 실행이니깐...
    }
}
