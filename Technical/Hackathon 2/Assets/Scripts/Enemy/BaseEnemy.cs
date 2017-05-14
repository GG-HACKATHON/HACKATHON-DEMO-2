using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : BaseMovementObject {

    protected float health;

    public void MinusHealth(float minusHealth)
    {
        this.health -= minusHealth;
        if (health <= 0)
            Debug.Log("die");
    }
}
