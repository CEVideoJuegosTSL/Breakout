using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticValues : Singleton<StaticValues>
{
    // Start is called before the first frame update
    public int life = 0;
    public int score;
    
    public int difficulty = 0;
    public AudioSource song;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLife(){
         return life;
    }
    public void SetLife(int i){
        life = i;
    }

    public int GetScore(){
        return score;
    }

    public void SetScore(int i){
        score = i;
    }

    public int GetDifficulty(){
        return difficulty;
    }

    public void SetDifficulty(int i){
        difficulty = i;
    }

}
