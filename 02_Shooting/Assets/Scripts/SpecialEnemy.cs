using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy : Enemy // Enemy 상속받은 파워업 아이템 드랍용 적 비행기
{
    public GameObject powerUp; // SpecialEnemy에 붙어있는 파워업 아이템

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // 오버라이드 해서 파워업 아이템을 처리 추가
        if (collision.gameObject.CompareTag("Bullet"))
        {
            powerUp.transform.parent = null;
            powerUp.SetActive(true);
        }
        base.OnCollisionEnter2D(collision);
    }
}
