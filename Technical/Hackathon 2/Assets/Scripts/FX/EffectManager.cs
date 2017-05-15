using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE_FX
{
    None = 0,
    ElectricBoll = 1,
    ElectricBolt = 2,
    Explode = 3,
    Firework = 4,
    ExplodeSmall = 5,
    ExplodeSmoke = 6,
    HitRed = 7,
    HitWhite = 8,
    AuraWall = 9,
    Flash = 10,
    Slash = 11,
    HitYellow = 12,
    AuraSpike = 13,
    Virus = 14,
    Smoke = 15,
    WaterSplash = 16
}

public class EffectManager : MonoSingleton<EffectManager>
{
    public GameObject[] prefabs;

    public void Spawn(TYPE_FX type, Vector3 location)
    {
        Instantiate(prefabs[(int)type], location, Quaternion.identity);
    }

    //GameObject tempObject;
    //ParticleSystem tempParticle;
    //public void Spawn(TYPE_FX type, Vector3 location, float scale, float angleRotate = 0)
    //{

    //    tempObject = Instantiate(prefabs[(int)type], location, Quaternion.identity) as GameObject;


    //    // scale
    //    tempParticle = tempObject.GetComponent<ParticleSystem>();

    //    var main = tempParticle.main;
    //    main.startSizeMultiplier = scale;    
    //    Debug.Log("Scale to: " + scale);

    //    //mainParticle.startSize.curveMin *= scale;
    
    //    //tempObject.transform.Rotate(0, 0, angleRotate);
    //}

    public TYPE_FX typeTest;
    public Vector3 locationTest;
    //public float scaleTest;
    //public float angleTest;

    [ContextMenu("SpawnTest")]
    public void SpawnTest()
    {
        //Spawn(typeTest, locationTest, scaleTest, angleTest);
        Spawn(typeTest, locationTest);
    }
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnTest();
        }
	}
}
