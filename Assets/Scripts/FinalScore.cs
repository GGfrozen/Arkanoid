using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalScore : MonoBehaviour
{
    GameManager gameManager;
    ScenesLoader scenesLoader;
    public Text finalScore;


    
    void Start()
    {
       gameManager = FindObjectOfType<GameManager>();
       scenesLoader = FindObjectOfType<ScenesLoader>();
    }
    void Update()
    {
        SetScore();
    }
   
    void SetScore()
    {
        int index = scenesLoader.ReturnIndex();
        if (index != 0)
        {
            GetFinalScore(gameManager.score);
        }
        else
        {
            ModifyBestScore(gameManager.score);
            SetBestScore();
            gameManager.score = 0;          
        }
    }
    void ModifyBestScore(int score)
    {
        int currentScore = PlayerPrefs.GetInt("BestScore", 0);
        if(score>currentScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        
    }
    void GetFinalScore(int score)
    {
        finalScore.text = "SCORE : " + score;
    }
    void SetBestScore()
    {
        int score = PlayerPrefs.GetInt("BestScore",0);
        finalScore.text = "BEST SCORE : " + score;
    }

    
}
