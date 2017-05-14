using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    PANDA
}

public class BasePlayer : MonoBehaviour {

    protected float health;

    PlayerType type;

    Animator anim;

	// Use this for initialization
	
	// Update is called once per frame
	public virtual void OnUpdate()
    {
        UpdateKeyboard();
    }

    public virtual void OnStart()
    {
        anim = GetComponent<Animator>();
    }

    void UpdateKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
        }
    }


}
