using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
   public Button start, option, quit;
   public TMP_Text text, shadow;
    // Start is called before the first frame update
    void Start()
    {
        StaticValues sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        text.text = sv.GetScore() + " points";
        shadow.text = sv.GetScore() + " points";
        
        start.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LevelOneScene");
        });
        option.onClick.AddListener(() =>{
            OptionsInterface();
        });
        quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
#else
        Application.Quit();
#endif
    }

    void OptionsInterface(){
        
    }
}
