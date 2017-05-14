using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZZZ : MonoBehaviour {

    public enum ZDIRECT
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public Vector3 mover;
    public float speed;


	void Update ()
    {
        transform.position += mover * Time.deltaTime * speed;

        

    }


    public void Move(ZDIRECT dir)
    {
        switch (dir)
        {
            case ZDIRECT.Up:
                {
                    mover = Vector2.up;
                }
                break;
            case ZDIRECT.Down:
                mover = Vector2.down;
                break;
            case ZDIRECT.Left:
                mover = Vector2.left;
                break;
            case ZDIRECT.Right:
                mover = Vector2.right;
                break;
            default:
                break;
        }
    }

}
