using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float ElapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;
        int minute = Mathf.FloorToInt(ElapsedTime / 60);
        int seconde = Mathf.FloorToInt(ElapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minute, seconde);
    }
}
