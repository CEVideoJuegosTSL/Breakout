using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab, paddle, heart1, heart2, heart3;

    public List<GameObject> bricksList;
    public int score;

    int hp;

    Dictionary<int, GameObject> bricks = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> balls = new Dictionary<int, GameObject>();

    StaticValues sv;
    // Start is called before the first frame update
    void Start()
    {
        sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        sv.SetLife(6);
        score = sv.GetScore();
        hp = 6;
        foreach(GameObject brick in bricksList){
            bricks.Add(brick.GetInstanceID(), brick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(balls.Count == 0){
                GameObject b = Instantiate(ballPrefab, new Vector3(paddle.transform.position.x, -2f, 0f), new Quaternion());
                balls.Add(b.GetInstanceID(), b);
            }
        }
    }

    public void DestroyBall(GameObject inputBall){
        balls.Remove(inputBall.GetInstanceID());
        if(balls.Count == 0){
            HPDown();
            score--;
            sv.SetScore(score);
        }
    }

    public void HitBrick(){
        score++;
        sv.SetScore(score);
    }

    public void CreateBall(GameObject inputBall){
        GameObject b = Instantiate(ballPrefab, new Vector3(inputBall.transform.position.x, inputBall.transform.position.y, 0f), new Quaternion());
        balls.Add(b.GetInstanceID(), b);
    }

    public Dictionary<int, GameObject> GetBalls(){
        Dictionary<int, GameObject> newBalls = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, GameObject> b in balls){
            newBalls.Add(b.Key, b.Value);
        }
        return newBalls;
    }

    public void PaddleUpgrade(){
        paddle.GetComponent<Paddle>().PaddleUpgrade();
    }

    private void HPDown(){
        hp--;
        sv.SetLife(hp);
        switch(hp){
            case 5:
                heart3.GetComponent<HPVisual>().UpdateSprite(1);
            break;
            case 4:
                heart3.GetComponent<HPVisual>().UpdateSprite(0);
            break;
            case 3:
                heart2.GetComponent<HPVisual>().UpdateSprite(1);
            break;
            case 2:
                heart2.GetComponent<HPVisual>().UpdateSprite(0);
            break;
            case 1:
                heart1.GetComponent<HPVisual>().UpdateSprite(1);
            break;
            case 0:
                heart1.GetComponent<HPVisual>().UpdateSprite(0);
                Invoke("Death", 0.5f);
            break;
        }
    }

    public void RestoreHP(){
        hp = 6;
        sv.SetLife(hp);
        heart3.GetComponent<HPVisual>().UpdateSprite(2);
        heart2.GetComponent<HPVisual>().UpdateSprite(2);
        heart1.GetComponent<HPVisual>().UpdateSprite(2);
    }

    void Death(){
        SceneManager.LoadScene("DeathScene");
    }
}
