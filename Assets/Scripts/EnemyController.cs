using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HealthController
{
    
    public override void death()
    {
        alive = false;
        Destroy(this.gameObject);
        //Play death animation
    }
}
