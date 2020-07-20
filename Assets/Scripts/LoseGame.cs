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
    public Image[] images;

    private void Start()
    {
        scenesLoader = FindObjectOfType<ScenesLoader>();
        ball = FindObjectOfType<Ball>();
        
        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            Ball[] balls = FindObjectsOfType<Ball>();
            if (balls.Length > 1)
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
        HeartOff(health);
        if (health != 0)
        {
            ball.ReturnBall();
        }
        else
        {
            scenesLoader.LoadLastScene();
        }
        
    }
   
    public void ModifyHealth(int modificator)
    {
        if(health != 0)
        {
            health += modificator;
            HeartOn(health);

        }
       
    }
  void HeartOn(int index)
    {
        if(health<=5)
        {
            images[index - 1].gameObject.SetActive(true);
        }
        
    }
    void HeartOff(int index)
    {
        if (health <= 5)
        {
            images[index].gameObject.SetActive(false);
        }
            
    }

}
