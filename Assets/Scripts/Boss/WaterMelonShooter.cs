using System.Collections;
using UnityEngine;

public class WatermeloonShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int numberOfProjectiles = 20;
    public float projectileSpeed = 10f;
    public float startAngle = 0f, endAngle = 360f;
    public float delay = 1; // Tirs par seconde
    private float angleOffset = 0;

    private float nextFireTime = 0f;
    private float nextConeFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireCircularPattern();
            nextFireTime = Time.time + delay;
        }
        if (Time.time >= nextConeFireTime)
        {
            FireConeAtTargetPlayer();
            nextConeFireTime = Time.time + delay*10;
        }
    }

    void FireConeAtTargetPlayer()
    {
        
        GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player");
        Vector3 targetPosition = targetPlayer.transform.position + new Vector3(0, 2, 0);
        Vector3 targetDirection = targetPosition - transform.position;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            GameObject tempProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody tempRigidbody = tempProjectile.GetComponent<Rigidbody>();
            //adjust velocity to make a circular pattern toward the player using the targetDirection
            tempRigidbody.velocity = targetDirection.normalized * projectileSpeed * 2 + new Vector3(Mathf.Sin(i * 2 * Mathf.PI / numberOfProjectiles), Mathf.Cos(i * 2 * Mathf.PI / numberOfProjectiles), 0) * projectileSpeed * 0.1f;

            Destroy(tempProjectile, 20f);
        }
    }

    void FireCircularPattern()
    {
        float angleStep = (endAngle - startAngle) / numberOfProjectiles;
        float angle = startAngle + angleOffset;
        angleOffset += 10;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            for (int y = 0; y < 5; y++)
            {
                float projectileDirXposition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
                float projectileDirZposition = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180);

                Vector3 projectileVector = new Vector3(projectileDirXposition, transform.position.y, projectileDirZposition);
                Vector3 projectileMoveDirection = (projectileVector - transform.position).normalized * projectileSpeed;

                GameObject tempProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                
                Rigidbody tempRigidbody = tempProjectile.GetComponent<Rigidbody>();

                Destroy(tempProjectile, 20f);

                tempRigidbody.velocity = new Vector3(projectileMoveDirection.x, y - 2.5f, projectileMoveDirection.z);

                angle += angleStep;
            }
        }
    }
}