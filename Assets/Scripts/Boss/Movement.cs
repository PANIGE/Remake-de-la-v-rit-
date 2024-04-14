using UnityEngine;

public class WatermelonChaser : MonoBehaviour
{
    public Transform player; // R�f�rence � la position du joueur
    public float chaseForce = 10f; // Force de poursuite appliqu�e � la past�que
    public float maxVelocity = 5f; // Vitesse maximale de la past�que
    public float jumpForce = 300f; // Force de saut appliqu�e � la past�que
    public float jumpThreshold = 15f; // Distance � partir de laquelle la past�que sautera
    private Rigidbody rb; // R�f�rence au Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from this game object");
        }
    }

    void FixedUpdate()
    {
        ApplyChaseForce();
        TryJumpTowardsPlayer();
    }

    void ApplyChaseForce()
    {
        if (player != null && rb != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            // Appliquer une force pour d�placer la past�que
            if (rb.velocity.magnitude < maxVelocity*4)
            {
                rb.AddForce(direction * chaseForce);
            }

            // Aligner la rotation de la past�que vers le joueur sans affecter la physique
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * chaseForce);
        }
    }

    void TryJumpTowardsPlayer()
    {
        if (player != null && rb != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > jumpThreshold)
            {
                // Appliquer une force de saut en direction du joueur
                Vector3 jumpDirection = (player.position - transform.position).normalized + Vector3.up;
                rb.AddForce(jumpDirection * jumpForce);
            }
        }
    }
}
