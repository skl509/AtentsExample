using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action onGameStart;

    Player player;
    Timer timer;
    ResultPannel resultPannel;

    bool isGameStart = false;

    public Player Player { get => player; }
    public bool IsGameStart
    {
        get => isGameStart;
        private set
        {
            isGameStart = value;
            if (isGameStart)
            {
                onGameStart?.Invoke();
            }
        }
    }

    protected override void Initialize()
    {
        isGameStart = false;
        player = FindObjectOfType<Player>();
        timer = FindObjectOfType<Timer>();
        resultPannel = FindObjectOfType<ResultPannel>();
        resultPannel?.gameObject.SetActive(false); // resultPannel이 null 값이 아닐때만 실행
    }

    public void GameStart()
    {
        if (!isGameStart)
        {
            IsGameStart = true;
        }
    }
    public void ShowResultPannel()
    {
        if (resultPannel != null)
        {
            resultPannel.ClearTime = timer.ResultTime;
            resultPannel?.gameObject?.SetActive(true);
        }
        }

    }