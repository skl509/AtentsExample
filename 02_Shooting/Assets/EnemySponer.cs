
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;


// 1.EnemySponer.cs를 수정 하여 Enemy 프리팹을 지속적으로 생성하게 만들어보기.
// 1.1 반드시 코루틴으로 작성해야 한다.

public class EnemySponer : MonoBehaviour
{   // 필요한 변수가 무엇인가? -> Enemy 프리팹, 지속적으로 동작을 하는 시간 간격
    // 필요한 기능은 무엇인가? -> Enemy 프래팹을 생성하는 코루틴

    PlayerInputAction inputActions;
    public GameObject enemy; // 생성할 적의 프리팹
    public float interval = 0.5f; // 시간 
    float minY = -4.0f; // 스폰이 일어나는 최저 높이
    float maxY = 4.0f; // 스폰이 일어나는 최고 높이

    private void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {

        while (true)
        {
            GameObject obj = Instantiate(enemy, transform); // 자기 자신을 생성하는 것 , transform 자기자신위치
            obj.transform.Translate(0, Random.Range(minY, maxY), 0); // 스폰 생성 범위 안에서 랜덤으로 높이 정하기
            yield return new WaitForSeconds(interval); // interval만큼 대기
        }




    }
    private void OnDrawGizmos()
    {
        // Gizmos.color = new Color(1,0,0);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY)+2, 1)); //내 주변 중심으로 가로 두칸 새로 5칸 z로 1칸 영역만든다
       // Gizmos.DrawCube(transform.position, new(2, 6, 1));
    }

    private void OnDrawGizmosSelected()
    {

    }





}