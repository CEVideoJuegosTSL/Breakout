using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button start, option, quit;
    // Start is called before the first frame update
    void Start()
    {
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
