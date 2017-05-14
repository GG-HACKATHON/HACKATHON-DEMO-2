using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    
    public GameObject panda;
    public Companion leader;

    List<GameObject> line = new List<GameObject>();

    public void Awake()
    {
        line.Add(leader.gameObject);
    }

    [ContextMenu("Add companion")]
    public void AddCompanion()
    {
        GameObject go = Instantiate(panda, transform) as GameObject;

        if (line.Count > 0)
        {
            go.GetComponent<Companion>().leader = line[0];
            go.GetComponent<Companion>().number = line.Count;
            line.Add(go);
        }
        else
        {
            line.Add(go);
        }
    }

    public virtual void TurnLeft()
    {
        line[0].GetComponent<Companion>().TurnLeft();
    }

    public virtual void TurnRight()
    {
        line[0].GetComponent<Companion>().TurnRight();
    }

    public virtual void TurnDown()
    {
        line[0].GetComponent<Companion>().TurnDown();
    }

    public virtual void TurnUp()
    {
        line[0].GetComponent<Companion>().TurnUp();
    }

    public void RemoveLastCompanion()
    {
        Destroy(line[line.Count - 1].gameObject);
        line.RemoveAt(line.Count - 1);
    }
}
