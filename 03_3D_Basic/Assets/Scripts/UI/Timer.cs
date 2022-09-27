using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timeText; // 움직이려는 텍스트 변수 생성

    float currentTime = 0.0f; // 초기시간설정
    bool isStart = false; // 스타트 햇는지 안햇는지 논리형으로 생성

    float CurrentTime { //최근시간 생성위해서 파라미터 생성
    
        get => currentTime;
        set 
        
        {   
            currentTime = value;
            timeText.text = $"{currentTime:f2} 초";


        }
    
    
    
    }
    private void Start()
    {
        Goal goal = FindObjectOfType<Goal>();
        goal.onGoalIn += StopTimer;

        // CurrentTime = 0.0f;
        StartTimer();
    }
    private void Awake()
    {
        timeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) 
    //{

    //    StartTimer();
    //}

 

    private void Update()
    {
        if (isStart) 
        {

            CurrentTime += Time.deltaTime;
        
        }
    }
    void StartTimer()
    { 
        isStart = true;
        CurrentTime = 0.0f;
    }

    void StopTimer() 
    {
    isStart=false;
    
    }


}
