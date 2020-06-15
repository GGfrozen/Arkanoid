using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Platform platform;
    Rigidbody2D rb;
    Vector3 ballOffset;
    Block block;

    bool makeExplosive;
    bool started;
    bool sticky;
    public float speed;

    [Header("Explode")]
    public float explodeRadius;

    public void MakeExplode()
    {
        makeExplosive = true;
    }
    public bool IsBallStarted()
    {
        return started;
    }

    public void MakeSticky()
    {
        sticky = true;
    }
    private void Awake()
    {
        started = false;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        platform = FindObjectOfType<Platform>();
        block = FindObjectOfType<Block>();
        ballOffset = transform.position - platform.transform.position;
        
    }  
    void Update()
    {
        if(started)
        {

        }
        else
        {
            MoveWithPlatform();
        }        
    }
    void MoveWithPlatform()
    {
        //transform.position = new Vector3(platform.transform.position.x, transform.position.y, 0);
        transform.position = platform.transform.position + ballOffset;
        if (Input.GetMouseButtonDown(0))
        {
            
            LaunchBall();
        }
    }
    public void LaunchBall()
    {
        started = true;
        Vector2 speedVector = new Vector2(Random.Range(-2,2),Random.Range(1,2));
        rb.velocity = speedVector * speed;
    }

    public void Duplicate()
    {
        Ball newBall = Instantiate(this);
        newBall.LaunchBall();
        if(sticky)
        {
            newBall.MakeSticky();
        }
    }
   
    private void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.velocity);
            Gizmos.DrawWireSphere(transform.position, explodeRadius);
        }

    }
    public void ModifySpeed(float modificator)
    {
        rb.velocity *= modificator;
    }

    public void ModifyScale(float modificator)
    {
        transform.localScale *= modificator;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if(sticky)
            { 
                started = false;
                rb.velocity = Vector3.zero;
                ballOffset = transform.position - platform.transform.position;
            }
           
        }
        if(collision.gameObject.CompareTag("Block"))
        {
            MakeExplosive();
        }
    }
    private void MakeExplosive()
    {
        if(makeExplosive == true)
        {
            LayerMask layerMask = LayerMask.GetMask("Block");
            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
            foreach (Collider2D objectsI in objectsInRadius)
            {

                Block block = objectsI.gameObject.GetComponent<Block>();
                if (block != null)
                {
                    block.DestroyBlock();

                }


            }
        }
    }

    public void ReturnBall()
    {
        started = false;
        rb.velocity = Vector3.zero;
        transform.position = ballOffset;
    }
  
}
