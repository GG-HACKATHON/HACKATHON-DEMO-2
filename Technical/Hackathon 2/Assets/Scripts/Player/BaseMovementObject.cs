using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    PANDA
}

public class BaseMovementObject : MonoBehaviour {

    private enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    protected float health;

    PlayerType type;

    Animator anim;

    Direction direction;
	// Use this for initialization
	
	// Update is called once per frame
	public virtual void OnUpdate()
    {
        UpdateKeyboard();
        UpdateAnim();
    }

    public virtual void OnStart()
    {
        anim = GetComponent<Animator>();
        direction = Direction.DOWN;
    }

    public void UpdateKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.LEFT;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.RIGHT;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.UP;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.DOWN;
        }
    }

    public void UpdateAnim()
    {
        switch(direction)
        {
            case Direction.LEFT:
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;
            case Direction.RIGHT:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                break;
            case Direction.UP:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", true);
                anim.SetBool("isDown", false);
                break;
            case Direction.DOWN:
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", true);
                break;
        }
    }

}
