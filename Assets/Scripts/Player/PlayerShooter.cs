using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Drag your projectile prefab here
    public Transform projectileSpawnPoint; // Drag your projectile spawn point here
    private bool isShooting = false;
    private float shootTimer = 0;
    public float ShootingRate = 50; // Adjust the time between shots as needed
    private ThirdPersonController thirdPersonController;
    EnergySlider energySlider = null;

    void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        energySlider ??= EnergySlider.Instance;
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            if (energySlider.CanDoAction(2))
            {
                isShooting = true;
                energySlider.Regen = false;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            energySlider.Regen = true;
        }

        thirdPersonController.velocity = isShooting ? 3 : 5;

        if (!isShooting)
            return;

        shootTimer += Time.deltaTime;

        if (shootTimer >= ShootingRate / 1000f)
        {
            if (!energySlider.CanDoAction(2))
            {
                isShooting = false;
                energySlider.Regen = true;
                return;
            }
            ShootAtNearestEnemy();

            energySlider.Regen = false;
            energySlider.Energy -= 2;
            shootTimer = 0;
        }
    }

    void ShootAtNearestEnemy()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        if (nearestEnemy != null)
            projectile.transform.LookAt(nearestEnemy.transform);
        else
            projectile.transform.LookAt(transform.forward);



        //add dispersion to the projectile
        projectile.transform.Rotate(Random.Range(-2, 2), Random.Range(-2, 2), 0);

        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * 10000); // Adjust force as needed
        GetComponent<AudioSource>().Play(); // Play shooting sound

        projectile.transform.Rotate(90, 0, 0); // Adjust rotation as needed

        Destroy(projectile, 2); // Adjust time as needed

    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Boss");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, currentPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }
}