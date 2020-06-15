using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour
{
    ScenesLoader scenesLoader;
    Ball ball;

    public int health = 3;
    public Text healthText;


    private void Start()
    {
        scenesLoader = FindObjectOfType<ScenesLoader>();
        ball = FindObjectOfType<Ball>();
    }
    private void Update()
    {
        CurrentHealth(health);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            if (balls.Length != 1)
            {
                Destroy(collision.gameObject);
            }   
            else
            {
                DoAgain();
            }
                

        }        
    }

    private void DoAgain()
    {
        
        
            health--;
            if (health != 0)
            {
                ball.ReturnBall();
            }
            else
            {
                scenesLoader.LoadLastScene();
            }
        
    }
    void CurrentHealth(int health)
    {
        healthText.text = "LIFE : " + health;

    }
    public void ModifyHealth(int modificator)
    {
        if(health != 0)
        {
            health += modificator;
        }
       
    }
   

}
