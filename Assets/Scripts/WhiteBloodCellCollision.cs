using UnityEngine;

public class WhiteBloodCellCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Virus"))
        {
            Destroy(other.gameObject);
        }
    }
}
