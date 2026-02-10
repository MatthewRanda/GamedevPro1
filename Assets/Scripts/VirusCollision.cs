using UnityEngine;

public class VirusCollision : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cell"))
        {
        
            CellHealth cellHealth = other.GetComponent<CellHealth>();

            if (cellHealth != null)
            {
                cellHealth.TakeDamage(damageAmount);
            }

            
            Destroy(gameObject);
        }
    }
}
