using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Background_Planet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float minRightEnd = 40.0f;
    public float maxRightEnd = 60.0f;
    public float minHegith = -8.0f;
    public float maxHegith = -5.0f;

    const float movePositionX = -10.0f;
    
    private void Update()
    {   // 이 오브젝트는 왼쪽으로 매초 moveSpeed 만큼 이동한다.
        transform.Translate(moveSpeed * Time.deltaTime * -transform.right);
        //이 오브젝트는 movePositionX 보다 왼쪽으로 이동하면 오른쪽 끝으로 이동한다.
        if (transform.position.x < movePositionX) 
        {
            //오른쪽 끝의 위치는 minRightEnd ~ maxRightEnd 사이를 랜덤으로 결정한다.
            transform.Translate(transform.right * Random.Range(minRightEnd, maxRightEnd));
            //높이도(y위치) 도 min 값에서 max 사이 랜덤으로 바꾼다
            Vector3 newPos = transform.position;
            newPos.y = Random.Range(minHegith, maxHegith);
            transform.position = newPos;

        }
       
    }

    
}


