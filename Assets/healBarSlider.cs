using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBarSlider : MonoBehaviour
{
    public static HealBarSlider Instance { get; private set; }
    public Slider HealSlider;
    /*public Slider EasehealSlider;*/
    public float MaxHealth = 100f;
    public float Health;
    public GameObject youDiedText;
    private float LerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        HealSlider.maxValue = MaxHealth;
        HealSlider.value = MaxHealth;
        youDiedText.gameObject.SetActive(false);
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(HealSlider.value != Health)
        {
            HealSlider.value = Health;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            Health = MaxHealth;
        }

        if (Health <= 0)
        {
            Health = 1; // to avoid spam
            Time.timeScale = 0;
            youDiedText.gameObject.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
