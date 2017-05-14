using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager> {

    public List<GameObject> listEnemy;

    public float randomTime;

    private float currentTime;

    // Use this for initialization
	void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTime <= 0)
        {
            SpawnEnemy();
            currentTime = randomTime;
        }
        else
            currentTime -= Time.deltaTime;
	}

    [ContextMenu("Spawn enemy")]
    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        GameObject enemy = GameObject.Instantiate(listEnemy[Random.Range(0, 2)], randomPos, Quaternion.identity);
    }
}
