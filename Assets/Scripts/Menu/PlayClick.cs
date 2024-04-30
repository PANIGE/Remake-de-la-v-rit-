using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayClick : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayOnClick);

        Button btn2 = quitButton.GetComponent<Button>();
        btn2.onClick.AddListener(QuitOnClick);
    }
    
    void PlayOnClick()
    {
        SceneManager.LoadScene("save1");
    }
    void QuitOnClick()
    {
        Application.Quit();
    }
}
