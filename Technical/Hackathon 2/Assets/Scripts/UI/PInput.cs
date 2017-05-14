using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInput : MonoBehaviour
{
    public ZZZ zzz;


    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            zzz.Move(ZZZ.ZDIRECT.Up);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            zzz.Move(ZZZ.ZDIRECT.Down);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            zzz.Move(ZZZ.ZDIRECT.Left);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            zzz.Move(ZZZ.ZDIRECT.Right);

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        break;

                    case TouchPhase.Moved:
                        

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                    zzz.Move(ZZZ.ZDIRECT.Right);

                                }
                                else
                                {
                                    // MOVE LEFT
                                    zzz.Move(ZZZ.ZDIRECT.Left);
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                    zzz.Move(ZZZ.ZDIRECT.Up);
                                }
                                else
                                {
                                    // MOVE DOWN
                                    zzz.Move(ZZZ.ZDIRECT.Down);
                                }
                            }

                        }

                        break;
                }
            }
        }

    }
}
