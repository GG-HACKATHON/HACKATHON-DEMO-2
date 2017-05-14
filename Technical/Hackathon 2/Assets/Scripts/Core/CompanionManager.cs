using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionManager : MonoSingleton<CompanionManager> {

    public enum CompanionType
    {
        PANDA = 0,
        HIPPP = 1,
        TURTLE = 2
    }

    [System.Serializable]
    public class CompanionProperty
    {
        public CompanionType companionType;
        public GameObject companion;
    }

    public List<CompanionProperty> companions;

    public Dictionary<CompanionType, GameObject> dict = new Dictionary<CompanionType, GameObject>();

    public void Awake()
    {
        MakeDictionary();
    }

    public void MakeDictionary()
    {
        foreach (CompanionProperty cp in companions)
        {
            if (!dict.ContainsKey(cp.companionType))
            {
                dict.Add(cp.companionType, cp.companion);
            }
        }
    }

    public int GetLength()
    {
        return companions.Count;
    }

    public GameObject GetCompanionByType(CompanionType type)
    {
        if (dict.ContainsKey(type))
        {
            return dict[type];
        }

        return null;
    }
}
