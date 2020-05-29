using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthbar;
    public ShipCollision ship;
    
    private GodMode godMode;
    private Level1Controller[] level1Controller;
    private Level2Controller[] level2Controller;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            level2Controller = FindObjectsOfType(typeof(Level2Controller)) as Level2Controller[];
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            level1Controller = FindObjectsOfType(typeof(Level1Controller)) as Level1Controller[];
        }
    }

    void Awake()
    {
        this.godMode = GameObject.FindObjectOfType<GodMode>();
    }

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
        if (this.godMode != null && this.godMode.isEnabled()) return; // si esta el godmode no inflinge daño

        slider.value -= damage;
        healthbar.color = gradient.Evaluate(slider.normalizedValue);
        this.Check();
    }

    private void Check()
    {
        if (this.slider.value <= 0)
        {
            this.ship.explode();
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                this.level2Controller[0].gameOver();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                this.level1Controller[0].gameOver();
            }
        }
    }
}
