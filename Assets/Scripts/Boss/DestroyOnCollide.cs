using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealBarSlider.Instance.TakeDamage(10);
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
