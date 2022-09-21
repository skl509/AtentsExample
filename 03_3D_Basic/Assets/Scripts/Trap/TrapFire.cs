using System.Collections;
using UnityEngine;

public class TrapFire : TrapBase
{
    ParticleSystem ps;
    
    private void Awake()
    {
        
        ps = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    protected override void TrapActivate(GameObject target)
    {
        GameObject child = transform.Find("CFX4 Fire").gameObject; // 자식 찾아주기
        child.SetActive(true); // 자식 활성화 시키기
        ps.Play();
      
        StartCoroutine(EffectStop());

        IDead deadTarget = target.GetComponent<IDead>();
        if (deadTarget != null)
        {
            deadTarget.Die();   // 죽이는 함수 호출
        }
    }

    IEnumerator EffectStop()
    {
        yield return new WaitForSeconds(1);
        ps.Stop();
    }
}