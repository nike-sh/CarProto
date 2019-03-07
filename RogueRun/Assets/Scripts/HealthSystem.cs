using System.Collections;
using System;


public class HealthSystem {

    public event EventHandler OnHealthChange; 
    private float maxHealth;
    private float health;

    public HealthSystem(float maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetHealthPercent()
    {
        return health / maxHealth;
    }


    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health<0)
        {
            health = 0;
        }
        if (OnHealthChange != null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > 100)
        {
            health = maxHealth;
        }
        if (OnHealthChange != null)
        {
            OnHealthChange(this, EventArgs.Empty);
        }
    }


}
