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

public AudioSource sound;
   StaticValues sv;
    // Start is called before the first frame update
    void Start()
    {
        sv = GameObject.Find("StaticContent").GetComponent<StaticValues>();
        text.text = sv.GetScore() + " points";
        shadow.text = sv.GetScore() + " points";
        sv.SetScore(0);
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
