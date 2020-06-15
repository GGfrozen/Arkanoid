using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalScore : MonoBehaviour
{
    GameManager gameManager;
    ScenesLoader scenesLoader;
    public Text finalScore;


    int currentScore;
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
            GetBestScore(currentScore);
            gameManager.score = 0;          
        }
    }
    void ModifyBestScore(int score)
    {
        if(score>currentScore)
        {
            currentScore = score;

        }
    }
    void GetFinalScore(int score)
    {
        finalScore.text = "SCORE : " + score;
    }
    void GetBestScore(int score)
    {
        finalScore.text = "BEST SCORE : " + score;
    }

    
}
