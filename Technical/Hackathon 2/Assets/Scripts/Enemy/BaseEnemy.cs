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
        {
            GameManager.Instance.player.AddCompanionByType((CompanionManager.CompanionType)Random.Range(0, 3));
            Destroy(gameObject);
        }
        
            Debug.Log("die");
    }
}
