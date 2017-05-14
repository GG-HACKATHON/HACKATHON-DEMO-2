using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public GameObject panda;

    List<GameObject> line = new List<GameObject>();

    [ContextMenu("Add companion")]
    public void AddCompanion()
    {
        GameObject go = Instantiate(panda, transform) as GameObject;

        if (line.Count > 0)
        {
            go.GetComponent<Companion>().leader = line[line.Count - 1];
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
}
