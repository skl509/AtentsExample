using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Goal : MonoBehaviour
{
    public Action onGoalIn;

    ParticleSystem[] ps;


    private void Awake()
    {
        ps = transform.GetChild(2).GetComponentsInChildren<ParticleSystem>(); // 파티클 시스템 찾아주기
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 트리거 안에 플레이어 들어왓을때
        {

            PlayGoalInEffect(other.gameObject); //골인 이펙트 함수 실행
            onGoalIn?.Invoke(); // 들어왓을때 골인 함수실행
        
        }


    }
        void PlayGoalInEffect(GameObject target)
        {
        foreach(var effect in ps) // 안에 있는 배열 다 실행해주기
            effect.Play();
        //ps[0].Play();
        //ps[1].Play();
        }
}