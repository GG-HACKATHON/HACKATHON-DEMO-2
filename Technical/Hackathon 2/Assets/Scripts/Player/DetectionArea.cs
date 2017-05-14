using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour {
    private bool detected;

    private float timeToSpawn;

    private GameObject curEnemy;

    private List<BaseItem> listBaseItem;

	void Start () {
        timeToSpawn = 0.0f;
	}

    // Update is called once per frame
    void Update()
    {
        GameObject neddle = null;
        if (detected)
        {
            if (timeToSpawn <= 0)
            {
                timeToSpawn = 1.0f;
                neddle = GameObject.Instantiate(PlayerItemManager.Instance.Needle,
                        transform.parent.gameObject.transform.position,
                        Quaternion.identity);
                neddle.GetComponent<Neddle>().Target = curEnemy;
            }
            else
                timeToSpawn -= Time.deltaTime;
        }
       
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            curEnemy = target.gameObject;
            detected = true;
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            detected = false;                            
        }
    }
}
