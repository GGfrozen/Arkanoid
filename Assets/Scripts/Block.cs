using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    LevelManager levelManager;
    GameManager gameManager;
    SpriteRenderer sprite;

    public GameObject[] pickUps;
    public AudioClip destroySound;
    public GameObject destroyFx;

    public bool visibility = true;

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
        VisibilityBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        visibility = true;
        DestroyBlock();
    }
    public void DestroyBlock()
    {

        pointsToBreak -= 1;
        if (pointsToBreak == 0)
        {
            AudioSource destroyAudio = FindObjectOfType<AudioSource>();
            destroyAudio.PlayOneShot(destroySound);
            Destroy(gameObject);

            gameManager.AddScore(pointsPerBlock);


            if (pickUps.Length != 0)
            {
                int randomChance = Random.Range(0, 10);
                if (randomChance < 3)
                {
                    Vector3 pickupPosition = transform.position;
                    int pickUpIndex = Random.Range(0, pickUps.Length - 1);
                    GameObject pickUp = pickUps[pickUpIndex];
                    Instantiate(pickUp, pickupPosition, Quaternion.identity);
                }

            }
            if (destroyFx != null)
            {
                Vector3 destroyFxVector = transform.position;
                GameObject newObject = Instantiate(destroyFx, destroyFxVector, Quaternion.identity);
                Destroy(newObject, 1f);
            }
            if (isExploding)
            {
                LayerMask layerMask = LayerMask.GetMask("Block");
                Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);

                foreach (Collider2D objectsI in objectsInRadius)
                {
                    if (objectsI.gameObject == gameObject)
                    {
                        continue;
                    }

                    Block block = objectsI.gameObject.GetComponent<Block>();
                    if (block == null)
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

    public void VisibilityBlock()
    {
        if (visibility == false)
        {
            sprite.enabled = false;
        }
        else
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
