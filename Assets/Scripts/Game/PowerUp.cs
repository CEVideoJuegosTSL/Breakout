using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> sprites;
    public SpriteRenderer sr;
    int type;
    GameManager gm;

    public AudioSource sound;
    void Start()
    {
        StaticValues sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        if(sv.GetLife() == 6){
            type = Random.Range(0,2);
        }else{
            type = Random.Range(0,3);
        }
        Debug.Log("Tipo nº" + type);
        sr.sprite = sprites.ElementAt(type);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() { 
    }

    private void MoreBalls()
    {
        Dictionary<int, GameObject> balls = gm.GetBalls();
        try
        {
            foreach(GameObject ball in balls.Values)
            {
                gm.CreateBall(ball);    
            }
        }
        catch (InvalidOperationException e)
        {
            Debug.Log(e.ToSafeString());
        }
    }

    private void PaddleUp() { 
        gm.PaddleUpgrade();
    }

    private void RestoreHealth() { 
        gm.RestoreHP();
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            sound.Play();
            switch(type){
                case 0:
                    MoreBalls();
                    Debug.Log("PowerUp bolas extra");
                    break;
                case 1:
                    PaddleUp();
                    Debug.Log("PowerUp mejora paddle");
                    break;
                case 2:
                    RestoreHealth();
                    Debug.Log("PowerUp cura vida");
                    break;
            }
            Invoke("DestroyThis", 0.15f);
        }
        else if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyThis(){
        Destroy(gameObject);
    }
}
