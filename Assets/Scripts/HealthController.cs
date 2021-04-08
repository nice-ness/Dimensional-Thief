using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    protected int health = 3;

    public int maxHealth = 3;
    protected bool alive = true;
    // Start is called before the first frame update

    public int Health
    {
        get
        {
            return health;
        }
    }
    public bool Alive
    {
        get
        {
            return alive;
        }
    }
    public virtual void damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            health = 0;
            death();
        }
    }

    public virtual void heal(int val)
    {
        if (alive)
        {
            health += val;
            if (health > maxHealth)
                health = maxHealth;
        }
    }

    public virtual void death()
    {
        alive = false;
        Destroy(this.gameObject);
        //Play death animation
    }
}
