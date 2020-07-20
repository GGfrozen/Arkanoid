using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        if(musicPlayers.Length>1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
