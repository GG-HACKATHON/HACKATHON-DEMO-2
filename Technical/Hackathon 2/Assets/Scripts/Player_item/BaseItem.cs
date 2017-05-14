using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerItemType
{
    NEEDLE,
}

public class BaseItem : MonoBehaviour {

    protected PlayerItemType type;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            switch(type)
            {
                case PlayerItemType.NEEDLE:
                    target.gameObject.GetComponent<BaseEnemy>().MinusHealth(10);
                    break;
            }
            Destroy(gameObject);
        }
    }

    public virtual void Move(Vector3 direction, float speed)
    {
        this.gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void MoveTo(GameObject target, float speed)
    {
        if (target == null)
        {

            return;
        }
        Debug.Log("move move move");
        transform.position = Vector3.MoveTowards(gameObject.transform.position,
            target.transform.position,
            speed * Time.deltaTime);
    }
                         
}
