using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplode : MonoBehaviour
{
    private void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach(Ball ball in balls)
        {
            SpriteRenderer ballSprite = ball.GetComponent<SpriteRenderer>();
            ballSprite.color = Color.red;
            TrailRenderer ballRenderer = ball.GetComponent<TrailRenderer>();
            ballRenderer.material.color = Color.yellow;
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
