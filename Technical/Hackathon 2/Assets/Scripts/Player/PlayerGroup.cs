using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroup : MonoBehaviour
{
    private enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public int length;

    public GameObject pref;

    public float speed;

    public float rotationSpeed;

    public float minDisstance;

    private Dictionary<Direction, Vector3> directionList;

    private List<GameObject> listBody;

   Direction direction;

    private GameObject curBody;

    private GameObject prevBody;

    private float distance;

	// Use this for initialization
	void Start () {
        listBody = new List<GameObject>();
        directionList = new Dictionary<Direction, Vector3>();
        direction = Direction.RIGHT;
       
        for (int i = 0; i < length; i++)
            AddBody(pref);

        directionList.Add(Direction.LEFT, Vector3.left);
        directionList.Add(Direction.RIGHT, Vector3.right);
        directionList.Add(Direction.UP, Vector3.up);
        directionList.Add(Direction.DOWN, Vector3.down);
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateKeyboard();

        Move();
    }

    void AddBody(GameObject pref)
    {
        this.listBody.Add(pref);
            listBody[listBody.Count - 1] = GameObject.Instantiate(listBody[listBody.Count - 1],
           listBody[listBody.Count - 1].transform.position,
           Quaternion.identity);
    }
    
    void UpdateKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.LEFT;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.RIGHT;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Direction.UP;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.DOWN;

        if (Input.GetAxis("Horizontal") != 0)
            listBody[0].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

    void Move()
    {
        listBody[0].transform.Translate(directionList[direction] * speed * Time.smoothDeltaTime);

        for(int i = 1;i<listBody.Count;i++)
        {
            curBody = listBody[i];
            prevBody = listBody[i - 1];

            distance = Vector3.Distance(prevBody.transform.position, curBody.transform.position);

            Vector3 newPos = prevBody.transform.position;

            newPos.y = listBody[0].transform.position.y;

            float T = Time.deltaTime * distance / minDisstance * speed;

            if (T > 0.1f)
                T = 0.1f;

            listBody[i].transform.position = Vector3.Slerp(curBody.transform.position, prevBody.transform.position, T);
            listBody[i].transform.rotation = Quaternion.Slerp(curBody.transform.rotation, prevBody.transform.rotation, T);

        }
    }
}
