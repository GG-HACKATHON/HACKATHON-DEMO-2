using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBaseItem : MonoBehaviour
{
    public TYPE_ITEM type;

    private Animator anim;

	// Use this for initialization
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        anim.SetInteger("typeBall", (int)type);
    }


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
