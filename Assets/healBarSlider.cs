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
    private float LerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
            TakeDamage(10);
        }
        /*if(HealSlider.value != EasehealSlider.value)
        {
            EasehealSlider.value = Mathf.Lerp(EasehealSlider.value,Health,LerpSpeed);
        }*/
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
