using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject CameraController;
    public bool isPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePause();
        }
        
    }

   public void TogglePause()
    {
        if (HealBarSlider.Instance.Health <= 5) 
        {
            return;
        }
        isPaused = !isPaused;
        var Camera = CameraController.GetComponent<CameraController>();
        if (isPaused)
        {
            Time.timeScale = 0f;
            PauseScreen.SetActive(true);
            Camera.enabled = false;
        }
        else
        {
            Time.timeScale = 1f;
            PauseScreen.SetActive(false);
            Camera.enabled = true;
        }
    }
}
