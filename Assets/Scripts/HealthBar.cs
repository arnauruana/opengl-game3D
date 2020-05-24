using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthbar;
    public ShipCollision ship;
    public Level1Controller level1Controller;

    public void SetMaxHealth(int maxhealth)
    {
        slider.maxValue = maxhealth;
        healthbar.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        healthbar.color = gradient.Evaluate(slider.normalizedValue);
        this.Check();
    }

    public void Damage(int damage)
    {
        slider.value -= damage;
        healthbar.color = gradient.Evaluate(slider.normalizedValue);
        this.Check();
    }

    private void Check()
    {
        if (this.slider.value <= 0)
        {
            this.ship.explode();
             this.level1Controller.gameOver();
        }
    }
}
