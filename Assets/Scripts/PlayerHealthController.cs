using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerHealthController : HealthController
{


    public TextMeshProUGUI hpUI;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        alive = true;
    }

    public void updateUI()
    {
        hpUI.text = "" + Health;
    }

    public override void damage(int dmg)
    {
        health -= dmg;
        updateUI();//update UI
        if (health <= 0)
        {
            health = 0;
            death();
        }
    }

    public override void heal(int val)
    {
        if (alive)
        {
        health += val;
            if (health > maxHealth)
                health = maxHealth;
        }
        updateUI();//update UI
    }

    public void revive()
    {
        if (!alive)
        {
            alive = !alive;
            health = 1;
            //Call invincibility
            playerController.enabled = true;//Renable movement
            updateUI();//update UI
        }
    }

    public void revive(int reviveHealth)
    {
        if (!alive)
        {
            alive = !alive;
            health = reviveHealth;
            //Call invincibility
            playerController.enabled = true;//Renable movement
            updateUI();//update UI
        }
    }

    public override void death()
    {
        alive = false;
        playerController.enabled = false;//Stop movement
        //.5s invulnerability?
        //Play death animation
        //show death hud
        updateUI();
    }
}
