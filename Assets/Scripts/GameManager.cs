using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score;

    public bool autoplay;
    public float autoplaySpeed = 1.5f;

    bool pauseActive;

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

            }
            else
            {
                Time.timeScale = 0;
                pauseActive = true;

            }
        }
    }
    public void AddScore(int score)
    {
        this.score += score;
    }

  
}
