using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TrapSticky : TrapBase
{
    //들어오면 몇초동안 이동속도가 10%로 느려짐

    public float speedDebuff = 0.1f;
    public float duration = 3.0f;

    float originalSpeed= 0.0f;
    protected override void TrapActivate(GameObject target) 
    {

        Player player =  target.GetComponent<Player>();
        originalSpeed = player.moveSpeed;
        player.moveSpeed *= speedDebuff;
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Player player = other.GetComponent<Player>();
            StartCoroutine(ReleaseDebuff(player));
        }
    }

    IEnumerator ReleaseDebuff(Player player)
    {

        yield return new WaitForSeconds(duration);
        player.moveSpeed = originalSpeed;
    }

}
