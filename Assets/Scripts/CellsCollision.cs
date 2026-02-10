using UnityEngine;

public class CellPieceCollision : MonoBehaviour
{
    private CellHealth cellHealth;

    void Start()
    {
        cellHealth = GetComponentInParent<CellHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Virus"))
        {
            cellHealth.TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
