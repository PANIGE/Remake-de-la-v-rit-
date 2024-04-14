using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            BossLifeBar.Instance.TakeDamage(2);
            //reduce KB on boss hit to a max of 5
            

        }
        Destroy(gameObject);
    }
}
