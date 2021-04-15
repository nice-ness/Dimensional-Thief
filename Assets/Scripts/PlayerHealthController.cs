using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]
public class PlayerHealthController : HealthController
{
    private const string deadPlayerTag = "Dead";
    private const string playerTag = "Player";

    //Will be moved later shouldn't be attached to this scripted
    public Canvas deathCanvas, hpCanvas;
    public TextMeshProUGUI hpText;
    private PlayerController playerController;
    private ShootingController shootingController;
    
    //.5s invulnerability when hit?
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        shootingController = GetComponentInChildren<ShootingController>();
        Time.timeScale = 1;//unpause
        hpCanvas = Instantiate(hpCanvas);
        deathCanvas = Instantiate(deathCanvas);
        deathCanvas.gameObject.SetActive(false);
        //This is a mess but it works for now
        hpText = hpCanvas.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        alive = true;
        tag = playerTag;
    }

    public void updateUI()
    {
        hpText.text = "" + Health;
    }

    public override void damage(int dmg)
    {
        health -= dmg;
        updateUI();//update UI
        if (health <= 0)
        {//.5s Invulerability?
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
            shootingController.enabled = true;
            tag = playerTag;
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
            shootingController.enabled = true;
            tag = playerTag;
            updateUI();//update UI
        }
    }

    public override void death()
    {
        alive = false;
        playerController.enabled = false;//Stop movement
        shootingController.enabled = false;
        tag = deadPlayerTag;
        Time.timeScale = 0;//Pause Game
        //Play death animation
        //show death hud
        deathCanvas.gameObject.SetActive(true);
        updateUI();
    }
}
