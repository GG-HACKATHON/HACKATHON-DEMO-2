using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move(Vector3 direction, float speed)
    {
        this.gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public virtual void MoveTo(GameObject target, float speed)
    {
        Debug.Log("move move move");
        transform.position = Vector3.MoveTowards(gameObject.transform.position,
            target.transform.position,
            speed * Time.deltaTime);
    }
                         
}
