using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    float x, y = 1f;

    float speed = 5f;

    public Rigidbody2D rb;

    GameManager gm;
    
    void Start()
    {
        /*GameObject paddle = GameObject.Find("Paddle");
        this.*/
        x = Random.Range(-2f,2f);
        if(x== 0f){
            x = 0.5f;
        }
        rb.velocity = new Vector2(x * speed, y * speed);
        
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Destroy")){
            gm.DestroyBall(gameObject);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Paddle")){
            rb.velocity = new Vector2(rb.velocity.x * 1.05f, rb.velocity.y * 1.05f);  
        }
    }
}
