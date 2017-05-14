using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMan : BaseEnemy {

    // Use this for initialization
    void Start()
    {
        health = 50;
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
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
