using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum TYPE_ITEM
{
    None,
    Gem,

    Boom = 11,
    Pepsi = 12

}

public class ItemSpawner : MonoBehaviour
{
    public float fTopLimit;
    public float fBottomLimit;
    public float fLeftLimit;
    public float fRightLimit;

    public float roundInterval;

    public GameObject[] prefabs;

    private Vector3 vecTemp = Vector3.zero;



	public void Spawn(TYPE_ITEM type)
    {
        vecTemp.x = Random.Range(fLeftLimit, fRightLimit);
        vecTemp.y = Random.Range(fTopLimit, fBottomLimit);

        switch (type)
        {
            //case TYPE_ITEM.Gem:
                //break;
            case TYPE_ITEM.Boom:
            case TYPE_ITEM.Pepsi:
                Instantiate(prefabs[(int)type], vecTemp, Quaternion.identity, null);
                break;
            default:
                Debug.Log("Spawn Item: nothing!");
                break;
        }
    }


    // -------------------------------------------
    public int numberToCall;

    [ContextMenu("SpawnAtNumber")]
    public void SpawnAtNumber()
    {
        Spawn((TYPE_ITEM)numberToCall);
    }
}