using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    public static BossLifeBar Instance { get; private set; }
    public GameObject Boss;
    public Slider Slider;
    public float BossHealth = 1200;
    public GameObject winText; 

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (Slider != null)
        {
            Slider.maxValue = BossHealth; 
            Slider.value = BossHealth; 
        }

        if (winText != null)
        {
            winText.gameObject.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Math.Abs(Slider.value - BossHealth) > 0.01f)
        {
            Slider.value = Mathf.Lerp(Slider.value, BossHealth, Time.deltaTime * 10); 
        }
        
        if (BossHealth <= 0)
        {
            Destroy(Boss);
            Time.timeScale = 0; // Freeze game time
            if (winText != null)
            {
                winText.gameObject.SetActive(true); 
            }
        }
    }
    
    public void TakeDamage(float damage)
    {
        if (BossHealth > 0)
        {
            BossHealth -= damage;
            BossHealth = Mathf.Clamp(BossHealth, 0, Slider.maxValue); // S'assurer que la santé ne dépasse pas les limites
        }
    }
}
