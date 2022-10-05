using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPannel : MonoBehaviour
{
    public Sprite[] medalSprits;

    ImageNumber score;
    ImageNumber bestScore;
    Image newMarkImage;
    Image medalImage;

    private void Awake()
    {
        score = transform.GetChild(0).GetComponent<ImageNumber>();
        bestScore = transform.GetChild(1).GetComponent<ImageNumber>();
        newMarkImage = transform.GetChild(2).GetComponent<Image>();
        medalImage = transform.GetChild(3).GetComponent<Image>();
    }

    public void RefreshScore()
    {
        int playerScore = GameManager.Inst.Score;
        score.Number = playerScore;

        //100 점 이상이면 브론즈 메달
        //200 점 이상이면은 실버 메달
        //300 점 이상이면 골드 메달
        //400 점 이상이면 플래티넘 메달
        if (playerScore >= 400)
        {
            medalImage.sprite = medalSprits[0];
            medalImage.color = Color.white; // RGB랑 알파값이 다 1로 고정됨
        }
        else if (playerScore >= 300)
        {
            medalImage.sprite = medalSprits[1];
            medalImage.color = Color.white;
        }
        else if (playerScore >= 200)
        {
            medalImage.sprite = medalSprits[2];
            medalImage.color = Color.white;
        }
        else if (playerScore >= 100)
        {
            medalImage.sprite = medalSprits[3];
            medalImage.color = Color.white;
        }
        else 
        {
            medalImage.color = Color.clear; // 아예 안보이게 만들기!
            
        }
    }

}