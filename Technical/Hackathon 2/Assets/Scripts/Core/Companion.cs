using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}

public class Companion : MonoBehaviour {

    Animator anim;

    Direction direction;

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
        switch (direction)
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

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public enum State {
        ALIVE,
        DEAD
    }

    public State state;
    public float hp;
    public float speed;
    public float damage;
    public int distance;
    public int number = 0; // number of order in line

    public GameObject leader;

    delegate void Action();
    Action Move;

    public class MoveRecoder
    {
        public Vector3 position;
        public Direction direction;

        public MoveRecoder(Vector3 position, Direction direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }

    List<MoveRecoder> recorder = new List<MoveRecoder>();
    float time = 0.1f;

    public virtual void Start()
    {
        Setup();
        OnStart();
    }

    public virtual void Update()
    {
        if (leader == null)
        {
            UpdateAnim();
            if (Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                TurnDown();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TurnUp();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TurnLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                TurnRight();
            }
            //UpdateKeyboard();
            recorder.Add(new MoveRecoder(transform.position, this.direction));
        }
        else
        {
            Move = MoveFollow;
        }

        Move();
    }

    public virtual void Setup()
    {
        // Trang thai alive
        state = State.ALIVE;
        Move = MoveDown;
    }

    public virtual void Setup(float hp, float speed, float damage) 
    {
        this.Setup();

        this.hp = hp;
        this.speed = speed;
        this.damage = damage;
    }

    public virtual void Setup(float hp, float speed, float damage, GameObject leader)
    {
        this.Setup(hp, speed, damage);
        this.leader = leader;
    }

    public virtual void MoveLeft() 
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public virtual void MoveRight() 
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public virtual void MoveUp() 
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public virtual void MoveDown() 
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public virtual void TurnLeft()
    {
        Move = MoveLeft;
        direction = Direction.LEFT;
    }

    public virtual void TurnRight()
    {
        Move = MoveRight;
        direction = Direction.RIGHT;
    }

    public virtual void TurnDown()
    {
        Move = MoveDown;
        direction = Direction.DOWN;
    }

    public virtual void TurnUp()
    {
        Move = MoveUp;
        direction = Direction.UP;
    }

    public virtual void MoveFollow()
    {
        var recorder = leader.GetComponent<Companion>().recorder;
        transform.position = recorder[recorder.Count - distance * number].position;
        direction = recorder[recorder.Count - distance * number].direction;
        UpdateAnim();
    }

    public virtual void OnHit() 
    { 
        // Tru HP tai day
    }

    public virtual void OnDead() 
    { 
        // Trang thai chet
        state = State.DEAD;
    }
}
