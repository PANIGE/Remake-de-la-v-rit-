using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healBarSlider : MonoBehaviour
{
    public Slider HealSlider;
    /*public Slider EasehealSlider;*/
    public float MaxHealth = 100f;
    public float Health;
    private float LerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
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
            takeDamage(10);
        }
        /*if(HealSlider.value != EasehealSlider.value)
        {
            EasehealSlider.value = Mathf.Lerp(EasehealSlider.value,Health,LerpSpeed);
        }*/
    }

    void takeDamage(float damage)
    {
        Health -= damage;
    }
}
