using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : BasePlayer {

	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
