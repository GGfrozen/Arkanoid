using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    ScenesLoader scenesLoader;
   
    
    int blocksNumber;
   

    private void Start()
    {
        scenesLoader = FindObjectOfType<ScenesLoader>();
        
    }
    private void Update()
    {
        
    }
    public void AddBlockCount()
    {
        blocksNumber++;
    }

    public void RemoveBlockCount()
    {
        blocksNumber--;
        if (blocksNumber <= 0)
        {
            scenesLoader.LoadNextLevel();
        }
    }

}
