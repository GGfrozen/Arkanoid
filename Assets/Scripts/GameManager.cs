using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image panel;
    public int score;

    public bool autoplay;
    public float autoplaySpeed = 1.5f;

    public bool pauseActive;

    Platform platform;

    private void Awake()
    {
        GameManager[] gameManager = FindObjectsOfType<GameManager>();
        if (gameManager.Length > 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        platform = FindObjectOfType<Platform>();
        
    }


    void Update()
    {
        GamePause();

        if (autoplay)
        {
            Time.timeScale = autoplaySpeed;
        }

    }

    private void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                if (autoplay)
                {
                    Time.timeScale = autoplaySpeed;
                }
                else
                {
                    Time.timeScale = 1;
                    
                }

                //Time.timeScale = autoplay == true ? autoplaySpeed : 1;
                pauseActive = false;
                platform.enabled = true;
            }
            else
            {
                Time.timeScale = 0;
                pauseActive = true;
                panel.gameObject.SetActive(true);
                platform.enabled = false;

            }
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
    }

    public void ReturnToGame()
    {
        
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
        platform.enabled = true;
    }
  
}
