using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthbar;

    public void SetMaxHealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        healthbar.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        healthbar.color = gradient.Evaluate(slider.normalizedValue);
    }
}
