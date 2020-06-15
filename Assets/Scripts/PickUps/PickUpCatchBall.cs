using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCatchBall : MonoBehaviour
{
   void ApplyEffect()
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        for (int i = 0;i<ball.Length;i++)
        {
            ball[i].MakeSticky();
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
