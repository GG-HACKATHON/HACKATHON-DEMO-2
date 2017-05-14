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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddCompanionByType((CompanionManager.CompanionType)Random.Range(0, 3));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RemoveLastCompanion();
        }
        
    }

    [ContextMenu("Add companion")]
    public void AddCompanion()
    {
        Vector3 pos = new Vector3(100, 100);
        GameObject go = Instantiate(panda, pos, Quaternion.identity, transform) as GameObject;

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

    public void AddCompanionByType(CompanionManager.CompanionType type)
    {
        
        GameObject ori = CompanionManager.Instance.GetCompanionByType(type);
        if (ori == null)
        {
            return;
        }

        Vector3 pos = new Vector3(100, 100);
        GameObject go = Instantiate(ori, pos, Quaternion.identity, transform) as GameObject;

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
