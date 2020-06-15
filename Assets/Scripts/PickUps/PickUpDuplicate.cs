using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDuplicate : MonoBehaviour
{
    public int newBallNumber = 2;

    void ApplyEffect()
    {
        Ball ball = FindObjectOfType<Ball>();
        for (int i = 0; i < newBallNumber; i++)
        {
            ball.Duplicate();
           
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("LoseGame"))
        {
            Destroy(gameObject);
        }

    }
}
