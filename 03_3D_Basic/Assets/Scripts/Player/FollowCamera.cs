using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    private void Start()
    {
        if (target == null) 
        {
            target = GameManager.Inst.Player.transform; // Find 보다 더 빠르다...
        
        }

        offset = transform.position - target.position; //캐릭터만 보는 방향 설정

    }

    private void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
