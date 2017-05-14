using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neddle : BaseItem {

    private GameObject target;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveTo(target, 2.5f);
    }

    public override void MoveTo(GameObject gameObject, float speed)
    {
        base.MoveTo(gameObject, speed);
    }
}
