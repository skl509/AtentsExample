using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //트리거에 들어오면 무조건 죽는것, IDeat 인터페이스를 가지고 있으면 무조건 죽인다.
        IDead target = other.GetComponent<IDead>();
        if (target != null) 
        {
            target.Die();
        }
    }

}
