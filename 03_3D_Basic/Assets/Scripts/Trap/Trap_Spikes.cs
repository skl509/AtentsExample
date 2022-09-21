using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Trap_Spikes : TrapBase
{

    public float power;
    bool isTouch = false;
    MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>(); // 매쉬렌더러 이미지 조작위해서
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            TrapActivate(other.gameObject); //캐릭터가 들어오면 작동
            isTouch = true; // 플레이어와 접촉하면 참값이됨
            mesh.enabled = false; // 매쉬랜더러 접촉하면 이미지 안보이게 만들기(랜더러해제)
        }

        IDead target = other.GetComponent<IDead>(); // 캐릭터가 들어오면 사망
        if (target != null)
        {
            target.Die();
        }


    }

    private void Update() 
    {
        if (isTouch) // 플레이어와 접촉할시 가시가 나오도록...
        {
            transform.Translate(Vector3.up * Time.deltaTime * power);
        }
    }
}
