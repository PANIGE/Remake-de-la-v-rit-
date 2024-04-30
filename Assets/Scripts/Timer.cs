using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    [SerializeField] TextMeshProUGUI timerText;
    public float ElapsedTime;
    public bool Elapsing = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Elapsing)
            return;
        ElapsedTime += Time.deltaTime;
        int minute = Mathf.FloorToInt(ElapsedTime / 60);
        int seconde = Mathf.FloorToInt(ElapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minute, seconde);
    }
}
