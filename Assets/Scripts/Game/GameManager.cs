using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject ballPrefab, paddle, heart1, heart2, heart3;

    public List<GameObject> bricksList;
    public int score;

    string sceneName;
    public GameObject canvas;
    int hp;
    bool finish = false, start = false;
    Dictionary<int, GameObject> bricks = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> balls = new Dictionary<int, GameObject>();

    public TMP_Text text, shadow;
    StaticValues sv;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        canvas.SetActive(false);
        if(!sceneName.Equals("ProceduralScene")){
            foreach(GameObject brick in bricksList){
                bricks.Add(brick.GetInstanceID(), brick);
            }
        }
        sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        hp = sv.GetLife();
        if(hp == 0){
            sv.SetLife(6);
            hp = 6;
        }else{
            ChangeSpriteHP();
        }
        score = sv.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("Ladrillos actuales: " + bricks.Count);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(sceneName);
            if(sceneName.Equals("ProceduralScene")){
                if(balls.Count == 0 && !finish && start){
                    GameObject b = Instantiate(ballPrefab, new Vector3(paddle.transform.position.x, -2f, 0f), new Quaternion());
                    balls.Add(b.GetInstanceID(), b);
                }
            }else{
                if(balls.Count == 0 && !finish){
                    start = true;
                    GameObject b = Instantiate(ballPrefab, new Vector3(paddle.transform.position.x, -2f, 0f), new Quaternion());
                    balls.Add(b.GetInstanceID(), b);
                }
            }
        }
        if(bricks.Count == 0 && start){
            finish = true;
            ShowWin();
        }
    }

    private void ShowWin(){
        canvas.SetActive(true);
        Invoke("ChangeScene", 3f);
    }

    private void ChangeScene(){
        if(sceneName.Equals("ProceduralScene")){
            int d = sv.GetDifficulty();
            sv.SetDifficulty(d++);
            text.text = "Nivel " + d + " completado";
            shadow.text = text.text;
            SceneManager.LoadScene("ProceduralScene");
        }else{
            SceneManager.LoadScene("LevelTwoScene");
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

    public void DestroyBrick(GameObject brick){
        bricks.Remove(brick.GetInstanceID());
    }

    public void CreateBrick(GameObject inputBrick){
        bricks.Add(inputBrick.GetInstanceID(), inputBrick);
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
        if(!finish){
            hp--;
            sv.SetLife(hp);
            ChangeSpriteHP();
        }
    }

    public void RestoreHP(){
        hp++;
        sv.SetLife(hp);
        ChangeSpriteHP();
    }

    void Death(){
        SceneManager.LoadScene("DeathScene");
    }

    private void ChangeSpriteHP(){
        switch(hp){
            case 6:
                heart3.GetComponent<HPVisual>().UpdateSprite(2);
            break;
            case 5:
                heart3.GetComponent<HPVisual>().UpdateSprite(1);
            break;
            case 4:
                heart3.GetComponent<HPVisual>().UpdateSprite(0);
                heart2.GetComponent<HPVisual>().UpdateSprite(2);
            break;
            case 3:
                heart3.GetComponent<HPVisual>().UpdateSprite(0);
                heart2.GetComponent<HPVisual>().UpdateSprite(1);
                heart1.GetComponent<HPVisual>().UpdateSprite(2);
            break;
            case 2:
                heart3.GetComponent<HPVisual>().UpdateSprite(0);
                heart2.GetComponent<HPVisual>().UpdateSprite(0);
                heart1.GetComponent<HPVisual>().UpdateSprite(2);
            break;
            case 1:
                heart3.GetComponent<HPVisual>().UpdateSprite(0);
                heart2.GetComponent<HPVisual>().UpdateSprite(0);
                heart1.GetComponent<HPVisual>().UpdateSprite(1);
            break;
            case 0:
                heart1.GetComponent<HPVisual>().UpdateSprite(0);
                Invoke("Death", 0.3f);
            break;
        }
    }

    public void ReadyToStart(){
        start = true;
    }
}
