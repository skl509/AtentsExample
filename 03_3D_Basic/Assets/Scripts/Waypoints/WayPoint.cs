using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Transform[] waypoint;
    int index = 0; // 현재 향하고 있는 웨이포인트의 인덱스

    public Transform CuurentWaypoint { get => waypoint[index]; }
    private void Awake()
    {
        waypoint = new Transform[transform.childCount]; // Trans폼의 좌표 찾기위해 자식 찾기
        for (int i = 0; i < transform.childCount; i++) 
        {
        waypoint[i] = transform.GetChild(i);    
        }
    }


    Transform MoveToNextWaypoint() 
    {
        index++;
        index %= waypoint.Length; // index = index % waypoint.Length;
        return waypoint[index];
    }

}
