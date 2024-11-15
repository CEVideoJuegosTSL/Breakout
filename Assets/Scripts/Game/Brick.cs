using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update

    public int hp;
    public GameObject brick;

    public SpriteRenderer sr;
    public List<Sprite> sprites;
    public GameObject powerUp;
    public AudioSource hit;
    GameManager gm;
    void Start()
    {
        sr.sprite = sprites.ElementAt( hp - 1);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SetHP(int hp){
        this.hp = hp;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        hit.Play();
        if(hp>0){
            hp--;
        }
        gm.HitBrick();
        if(hp==0){
            Invoke("DestroyBrick", 0.2f);
            
        }else{
            sr.sprite = sprites.ElementAt( hp - 1);
        }
    }

    private void DestroyBrick(){
        if(Random.Range(1,6) > 4){
            Vector3 position = brick.transform.position;
            Instantiate(powerUp, position, new Quaternion());
        }
        gm.DestroyBrick(brick);
        Destroy(brick);
    }
}
