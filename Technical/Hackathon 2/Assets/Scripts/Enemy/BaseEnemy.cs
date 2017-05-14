using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    ROCKMAN,
    BIGBEAR
}

public class BaseEnemy : BaseMovementObject {

    protected float health;

    protected EnemyType type;

    public void MinusHealth(float minusHealth)
    {
        this.health -= minusHealth;
        if (health <= 0)
            Debug.Log("die");
    }
}
