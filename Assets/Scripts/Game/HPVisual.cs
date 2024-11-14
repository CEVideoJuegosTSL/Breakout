using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HPVisual : MonoBehaviour
{
    public SpriteRenderer sr;

    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = sprites.ElementAt(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite(int value){
        sr.sprite = sprites.ElementAt(value);
    }
}
