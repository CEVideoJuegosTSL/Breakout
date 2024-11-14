using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticValues : Singleton<StaticValues>
{
    // Start is called before the first frame update
    public int life;
    public int score;
    
    public AudioSource song;
    public AudioClip clipSong;

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

}
