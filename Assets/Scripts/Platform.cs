using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Ball ball;
    GameManager gameManager;
    

    public float minX;
    public float maxX;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();
        

    }


    void Update()
    {
        if (gameManager.autoplay && ball.IsBallStarted())
        {
            MoveWithBall();
        }
        else
        {
            MovePlatform();
        }


    }

    private void MovePlatform()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        float mouseX = mouseWorldPos.x;
        float clampX = Mathf.Clamp(mouseX, minX, maxX);
        float mouseY = transform.position.y;
        transform.position = new Vector3(clampX, mouseY, 0);
    }
    void MoveWithBall()
    {
        transform.position = new Vector3(ball.transform.position.x, transform.position.y, 0);
    }

    public void ModifyScale(float modificator)
    {
        Vector3 scaleX = transform.localScale;
        scaleX.x *= modificator;
        transform.localScale = scaleX;
    }
}
