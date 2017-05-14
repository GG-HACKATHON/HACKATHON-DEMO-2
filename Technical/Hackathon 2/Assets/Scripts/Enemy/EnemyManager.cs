using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager> {

    public List<GameObject> listEnemy;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("Spawn enemy")]
    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        GameObject enemy = GameObject.Instantiate(listEnemy[0], randomPos, Quaternion.identity);
    }
}
