using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timeText;

    float currentTime = 0.0f;
    bool isStart = false;

    float CurrentTime {
    
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