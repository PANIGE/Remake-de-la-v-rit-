using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public GameObject ScoreObjext;
    public GameObject TimerObjext;
    public GameObject DiedText;
    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {

        if (HealBarSlider.Instance.Health <= 1)
            DiedText.gameObject.SetActive(true);
        else
            WinText.gameObject.SetActive(true);

        ScoreObjext.GetComponent<TextMeshProUGUI>().text = "Score: " + ScoreManager.Instance.Score;
        int minute = Mathf.FloorToInt(Timer.Instance.ElapsedTime / 60);
        int seconde = Mathf.FloorToInt(Timer.Instance.ElapsedTime % 60);
        TimerObjext.GetComponent<TextMeshProUGUI>().text = "Time: " + string.Format("{0:00}:{1:00}", minute, seconde);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
