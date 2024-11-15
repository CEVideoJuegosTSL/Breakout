using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button start, option, quit;

    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(() =>
        {
            sound.Play();
            Invoke("ChangeScene", 0.2f);
        });
        option.onClick.AddListener(() =>{
            Invoke("OptionsInterface", 0.2f);
        });
        quit.onClick.AddListener(QuitGame);
    }
    private void ChangeScene(){
        SceneManager.LoadScene("LevelOneScene");
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
