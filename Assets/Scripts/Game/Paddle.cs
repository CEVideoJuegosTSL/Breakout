using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float speed;

    float initSpeed;

    public Rigidbody2D paddle;

    public SpriteRenderer sr;

    public List<Sprite> sprites;

    public AudioSource hit;
    Vector3 scale;
    // Start is called before the first frame update
    bool speedMod = false, scaleMod = false;
    void Start()
    {
        initSpeed = speed;
        scale = paddle.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        paddle.velocity = new Vector2(movement * speed, paddle.velocity.y);
        
    }

    public void PaddleUpgrade(){
        sr.sprite = sprites.ElementAt(1);
        int option = Random.Range(1,3);
        switch(option){
            case 1:
                scaleMod = true;
                gameObject.transform.localScale = new Vector3(scale.x * 1.5f, scale.y, scale.z);
                Invoke("SizeDowngrade", 5f);
            break;
            case 2:
                speedMod = true;
                speed = initSpeed * 1.5f;
                Invoke("SpeedDowngrade", 5f);
            break;
        }
    }

    private void SizeDowngrade(){
        gameObject.transform.localScale = scale;
        scaleMod = false;
        if(!speedMod){
            sr.sprite = sprites.ElementAt(0);
        }
    }

    private void SpeedDowngrade(){
        speed = initSpeed;
        speedMod = false;
        if(!scaleMod){               
            sr.sprite = sprites.ElementAt(0);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            hit.Play();
        }
    }
}
