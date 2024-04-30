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
    public float BossHealth = 1;
    public GameObject winText;
    
    public GameObject PlayerRoot;
    public GameObject Boss1Root;
    public GameObject Boss2Root;
    public GameObject Boss3Root;

    public GameObject TpLevel2;
    public GameObject TpLevel3;

    public long BetonHealth = 300;
    public long ReglisseHealth = 600;
    public long PastequeHealth = 1200;

    private int currentBoss = 1;
    private GameObject currentBossRoot;

    private bool loaded = false;



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        BossHealth = BetonHealth;
        Boss1Root.SetActive(true);
        Boss2Root.SetActive(false);
        Boss3Root.SetActive(false);
        currentBossRoot = Boss1Root;

        if (Slider != null)
        {
            Slider.maxValue = BossHealth; 
            Slider.value = BossHealth; 
        }

        if (winText != null)
        {
            winText.gameObject.SetActive(false); 
        }

        loaded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!loaded)
            return;

        if (Math.Abs(Slider.value - BossHealth) > 0.01f)
        {
            Slider.value = Mathf.Lerp(Slider.value, BossHealth, Time.deltaTime * 10); 
        }
        
        if (BossHealth <= 0)
        {
            currentBossRoot.SetActive(false);

            switch (currentBoss)
            {
                case 1:
                    Boss2Root.SetActive(true);
                    currentBossRoot = Boss2Root;
                    BossHealth = ReglisseHealth;
                    currentBoss = 2;
                    PlayerRoot.transform.position = TpLevel2.transform.position;
                    break;
                case 2:
                    Boss3Root.SetActive(true);
                    currentBossRoot = Boss3Root;
                    BossHealth = PastequeHealth;
                    currentBoss = 3;
                    PlayerRoot.transform.position = TpLevel3.transform.position;
                    break;
                case 3:
                    Time.timeScale = 0; // Freeze game time
                    if (winText != null)
                    {
                        winText.gameObject.SetActive(true);
                    }
                    return;

            }

            Slider.maxValue = BossHealth;
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
