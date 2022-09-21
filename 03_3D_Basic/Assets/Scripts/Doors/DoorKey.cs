using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour, IUseableObject
{
    public Door targetDoor;
   

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Use();
            Destroy(this.gameObject);
        }
    }
    public void Use()
    {

       
            // 스위치를 켰으면 targetDoor를 연다.
            targetDoor.Open();


    }
}
