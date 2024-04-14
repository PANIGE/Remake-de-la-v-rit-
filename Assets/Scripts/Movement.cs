using UnityEngine;

public class WatermelonMovement : MonoBehaviour
{
    public float speed = 5.0f; // Vitesse de déplacement de la pastèque
    private Vector3 targetPosition; // Position cible où se déplace la pastèque
    public double time = 0.0; // Temps écoulé depuis le début de la simulation

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        MoveTowardsTarget();
        time += Time.deltaTime;
        if (time > 10.0)
        {
            SetRandomTargetPosition();
            time = 0.0;
        }
    }

    void SetRandomTargetPosition()
    {
        // Génère une position aléatoire sur la plane de taille 20x20
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-10.0f, 10.0f);
        targetPosition = new Vector3(x, 0, z); // Assurez-vous que la coordonnée y est adaptée à votre scène
    }

    void MoveTowardsTarget()
    {
        // Déplace la pastèque vers la position cible
        Vector3 direction = targetPosition - transform.position;
        if (direction.magnitude < 0.5f) // Si la pastèque est proche de la cible
        {
            SetRandomTargetPosition(); // Choisir une nouvelle cible
        }
        else
        {
            direction.Normalize();
            // Applique un mouvement de rotation pour simuler le roulement
            GetComponent<Rigidbody>().AddForce(direction * speed);
        }
    }

    // Pour visualiser la position cible dans l'éditeur
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.5f);
    }
}
