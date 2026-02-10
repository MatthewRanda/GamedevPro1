using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public CellHealth cell;

    void Start()
    {
        slider.maxValue = cell.maxHealth;
        slider.value = cell.currentHealth;
    }

    void Update()
    {
        slider.value = cell.currentHealth;
    }
}
