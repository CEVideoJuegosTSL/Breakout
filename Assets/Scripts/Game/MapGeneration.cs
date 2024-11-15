using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    float xMinPos = -8.14f, xMaxPos = 8.14f, xMinDistance = 1.5f;
    int maxCol = 10, maxRow = 11;
    float yMinPos = -1f, yMaxPos = 4.75f, yMinDistance = 0.5f;

    public GameObject brickPrefab;
    StaticValues sv;
    GameManager gm;
    int difficulty;
    public GameObject spawner;
    void Start()
    {
        sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficulty = sv.GetDifficulty();
        StartCoroutine(SpawnBreaks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBreaks(){
        int maxBricksGeneric = 5;
        int numRow = Mathf.Clamp(Random.Range(0, maxBricksGeneric + difficulty), 2, 11);
        float timeStoppedXRow = 5f  / numRow;
        float xPos, yPos;
        for(int yCoord = numRow - 1; yCoord >= 0; yCoord--){
            yPos = Mathf.Lerp(yMinPos, yMaxPos, yCoord / (float)(numRow - 1f));
            int numCol = Mathf.Clamp(Random.Range(0, maxBricksGeneric + difficulty), 3, 10);
            float timeStopped = timeStoppedXRow / numCol;
            for(int xCoord = 0; xCoord < numCol; xCoord++){
                xPos = Mathf.Lerp(xMinPos, xMaxPos, xCoord / (float)(numCol - 1f));
                yield return new WaitForSeconds(timeStopped);
                Debug.Log("Ladrillo generado en X: " + xPos + " Y: " + yPos);
                createBrick(xPos, yPos);
            }
        }
        gm.ReadyToStart();
    }


    private void createBrick(float xPos, float yPos){
                GameObject brick = Instantiate(brickPrefab, new Vector3(xPos, yPos, 0f), new Quaternion(), spawner.transform);
                int brickHP = Random.Range(1, 4 + difficulty);
                brick.GetComponent<Brick>().SetHP(brickHP);
                gm.CreateBrick(brick);
    }
}
