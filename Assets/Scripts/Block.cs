using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    LevelManager levelManager;
    GameManager gameManager;
    SpriteRenderer sprite;

    public GameObject pickUp;

    [Header("Explode")]
    public bool isExploding;
    public float explodeRadius;


    [Header("Points")]
    public int pointsToBreak = 1;
    public int pointsPerBlock = 10;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.AddBlockCount();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        VisionBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }
    void DestroyBlock()
    {
        pointsToBreak -= 1;
        if (pointsToBreak == 0)
        {
            Destroy(gameObject);
            
            gameManager.AddScore(pointsPerBlock);
            

            if (pickUp != null)
            {
                Vector3 pickupPosition = transform.position;
                Instantiate(pickUp, pickupPosition, Quaternion.identity);
            }
            if (isExploding)
            {
                LayerMask layerMask = LayerMask.GetMask("Block");
                Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius,layerMask);
                
                foreach(Collider2D objectsI in objectsInRadius)
                {
                    if(objectsI.gameObject == gameObject)
                    {
                        continue;
                    }

                    Block block = objectsI.gameObject.GetComponent<Block>();
                    if(block == null)
                    {
                        Destroy(objectsI.gameObject);
                    }
                    else
                    {
                        block.DestroyBlock();
                    }

                    
                    
                }
                
            }
            levelManager.RemoveBlockCount();
        }

        
    }

    public void VisionBlock()
    {
        if (pointsToBreak == 5)
        {
            sprite.enabled = false;
        }
        else if (pointsToBreak <= 4)
        {
            sprite.enabled = true;
        }
    }
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }

}
