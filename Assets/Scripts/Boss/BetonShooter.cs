using System.Collections;
using UnityEngine;

public class BetonShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int numberOfProjectiles = 20;
    public float projectileSpeed = 10f;
    public float startAngle = 0f, endAngle = 360f;
    public float delay = 10; // Tirs par seconde

    private float nextConeFireTime = 0f;

    void FixedUpdate()
    {
        if (Time.time >= nextConeFireTime)
        {
            FireConeAtTargetPlayer();
            nextConeFireTime = Time.time + delay;
        }
    }

    void FireConeAtTargetPlayer()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

        GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player");
        Vector3 targetPosition =  targetPlayer.transform.position + new Vector3(0, 2, 0);
        Vector3 targetDirection = targetPosition - transform.position;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            GameObject tempProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody tempRigidbody = tempProjectile.GetComponent<Rigidbody>();
            //adjust velocity to make a circular pattern toward the player using the targetDirection
            tempRigidbody.velocity = targetDirection.normalized * projectileSpeed * 2 + new Vector3(Mathf.Sin(i * 2 * Mathf.PI / numberOfProjectiles), Mathf.Cos(i * 2 * Mathf.PI / numberOfProjectiles), 0) * projectileSpeed * 0.1f;

            //Destroy(tempProjectile, 20f);
        }
    }
    
}