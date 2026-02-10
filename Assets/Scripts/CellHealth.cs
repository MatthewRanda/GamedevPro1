using UnityEngine;

public class CellHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Vius touched the Cell! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Cell has died!");
            
        }
    }
}
