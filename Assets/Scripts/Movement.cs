using UnityEngine;

public class WatermelonMovement : MonoBehaviour
{
    public float speed = 5.0f; // Vitesse de d�placement de la past�que
    private Vector3 targetPosition; // Position cible o� se d�place la past�que
    public double time = 0.0; // Temps �coul� depuis le d�but de la simulation

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
        // G�n�re une position al�atoire sur la plane de taille 20x20
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-10.0f, 10.0f);
        targetPosition = new Vector3(x, 0, z); // Assurez-vous que la coordonn�e y est adapt�e � votre sc�ne
    }

    void MoveTowardsTarget()
    {
        // D�place la past�que vers la position cible
        Vector3 direction = targetPosition - transform.position;
        if (direction.magnitude < 0.5f) // Si la past�que est proche de la cible
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

    // Pour visualiser la position cible dans l'�diteur
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.5f);
    }
}
